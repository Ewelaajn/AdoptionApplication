using AdoptionApplication.Server.Data;
using AdoptionApplication.Server.Services.SpeciesService;
using AdoptionApplication.Shared;
using Microsoft.EntityFrameworkCore;

namespace AdoptionApplication.Server.Services.Animals
{
    public class AnimalService : IAnimalService
    {
        public ICollection<Animal> Animals { get; set; } = new List<Animal>();

        private readonly ISpeciesService _speciesService;
        private readonly DataContext _dataContext;

        public AnimalService(ISpeciesService speciesService, DataContext dataContext)
        {
            _speciesService = speciesService;
            _dataContext = dataContext;
        }

        public async Task<Animal> GetAnimalByIdAsync(int id) => await _dataContext.Animals.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<ICollection<Animal>> GetAnimalsAsync() => await _dataContext.Animals.AsNoTracking().Where(x => x.Deleted == false).ToListAsync();

        public async Task<ICollection<Animal>> GetAnimalsBySpeciesAsync(string speciesUrl)
        {
            var species = await _speciesService.GetSpeciesByUrlAsync(speciesUrl);
            return await _dataContext.Animals.AsNoTracking().Where(x => x.SpeciesId == species.Id).ToListAsync();
        }
    }
}
