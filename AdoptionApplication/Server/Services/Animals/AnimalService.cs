using AdoptionApplication.Server.Data;
using AdoptionApplication.Server.Services.SpeciesService;
using AdoptionApplication.Shared;
using AdoptionApplication.Shared.DTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AdoptionApplication.Server.Services.Animals
{
    public class AnimalService : IAnimalService
    {
        public ICollection<Animal> Animals { get; set; } = new List<Animal>();

        private readonly ISpeciesService _speciesService;
        private readonly DataContext _dataContext;
        private readonly IValidator<Animal> _validator;

        public AnimalService(ISpeciesService speciesService, DataContext dataContext, 
            IValidator<Animal> validator)
        {
            _speciesService = speciesService;
            _dataContext = dataContext;
            _validator = validator;
        }

        public async Task<Animal> GetAnimalByIdAsync(int id) => await _dataContext.Animals.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.Deleted == false);

        public async Task<BatchAnimal> GetAnimalsAsync(int? page, bool? isAdopted, string? city, string? province) 
        {
            var query = _dataContext.Animals.AsNoTracking()
                .OrderBy(x => x.Id).AsQueryable();
            
            query = PrepareQuery(query, isAdopted, city, province, default);
            var total = await query.CountAsync();
            query = ApplyPagination(query, page);
            
            return new BatchAnimal { Animals = await query.ToListAsync(), Total = total };
        } 

        public async Task<BatchAnimal> GetAnimalsBySpeciesAsync(string speciesUrl, int? page, bool? isAdopted, string? city, string? province)
        {
            var species = await _speciesService.GetSpeciesByUrlAsync(speciesUrl);

            var query = _dataContext.Animals.AsNoTracking()
                .OrderBy(x => x.Id).AsQueryable();

            query = PrepareQuery(query, isAdopted, city, province, species.Id);
            var total = await query.CountAsync();
            query = ApplyPagination(query, page);

            return new BatchAnimal { Animals = await query.ToListAsync(), Total = total };
        }

        private IQueryable<Animal> PrepareQuery(IQueryable<Animal> query, bool? isAdopted, string? city,
            string? province, int? speciesId)
        {
            if (isAdopted.HasValue)
                query = query.Where(x => x.IsAdopted == isAdopted);
            if (!string.IsNullOrWhiteSpace(city))
                query = query.Where(x => x.City == city);
            if (!string.IsNullOrWhiteSpace(province))
                query = query.Where(x => x.Province == province);
            if (speciesId.HasValue)
                query = query.Where(x => x.SpeciesId == speciesId);

            return query.Where(x => x.Deleted == false);
        }

        private IQueryable<Animal> ApplyPagination(IQueryable<Animal> query, int? page)
        {
            var toSkip = PaginationService.HowManyItemsSkip(page);
            if (toSkip != null)
                query = query.Skip(toSkip.Value).Take(PaginationService.PageItems);

            return query;
        }

        public async Task<Animal> UpsertAnimalAsync(Animal animal)
        {
            try
            {
                var validation = _validator.Validate(animal);
                if (!validation.IsValid)
                    return null;

                animal.DateOfBirth = DateTime.SpecifyKind(animal.DateOfBirth.Value, DateTimeKind.Utc);
                if(animal.AdoptionDate.HasValue)
                    animal.AdoptionDate = DateTime.SpecifyKind(animal.AdoptionDate.Value, DateTimeKind.Utc);
                if (animal.Id > 0)
                {
                    var dbAnimal = await _dataContext.Animals.AsNoTracking().FirstOrDefaultAsync(x => x.Id == animal.Id);
                    if (dbAnimal != null)
                    {
                        _dataContext.Entry(animal).State = EntityState.Modified;
                    }
                    else
                        _dataContext.Animals.Add(animal);
                }
                else if (animal.Id == 0 || animal.Id == null)
                {
                    _dataContext.Animals.Add(animal);
                }

                await _dataContext.SaveChangesAsync();
                return animal;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task DeleteAnimal(int id)
        {
            var animal = await _dataContext.Animals.FirstOrDefaultAsync(x => x.Id == id);
            if (animal == null) return;
            animal.Deleted = true;
            await _dataContext.SaveChangesAsync();
        }
    }
}
