using AdoptionApplication.Server.Data;
using AdoptionApplication.Server.Services.SpeciesService;
using AdoptionApplication.Shared;
using AdoptionApplication.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace AdoptionApplication.Server.Services.Animals
{
    public class AnimalService : IAnimalService
    { 
        private readonly ISpeciesService _speciesService;
        private readonly DataContext _dataContext;

        public AnimalService(ISpeciesService speciesService, DataContext dataContext)
        {
            _speciesService = speciesService;
            _dataContext = dataContext;
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
    }
}
