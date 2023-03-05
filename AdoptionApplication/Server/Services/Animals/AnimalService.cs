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

        public async Task<BatchAnimal> GetAnimalsAsync(int? page) 
        {
            var query = _dataContext.Animals.AsNoTracking().Where(x => x.Deleted == false);
            var total = await query.CountAsync();
            query = ApplyPagination(query, page);
            return new BatchAnimal { Animals = await query.ToListAsync(), Total = total };
        } 

        public async Task<BatchAnimal> GetAnimalsBySpeciesAsync(string speciesUrl, int? page)
        {
            var species = await _speciesService.GetSpeciesByUrlAsync(speciesUrl);
            
            var query = _dataContext.Animals.AsNoTracking()
                .OrderBy(x => x.Id)
                .Where(x => x.SpeciesId == species.Id && x.Deleted == false);

            var total = await query.CountAsync();
            query = ApplyPagination(query, page);

            return new BatchAnimal { Animals = await query.ToListAsync(), Total = total };
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
    }
}
