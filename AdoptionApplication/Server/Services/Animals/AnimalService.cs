using AdoptionApplication.Server.Services.SpeciesService;
using AdoptionApplication.Shared;
using AdoptionApplication.Shared.Constants;

namespace AdoptionApplication.Server.Services.Animals
{
    public class AnimalService : IAnimalService
    {
        public ICollection<Animal> Animals { get; set; } = new List<Animal>();

        private readonly ISpeciesService _speciesService;

        public AnimalService(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        public async Task<Animal> GetAnimalByIdAsync(int id) => Animals.FirstOrDefault(x => x.Id == id);

        public async Task<ICollection<Animal>> GetAnimalsAsync() => Animals;

        public async Task<ICollection<Animal>> GetAnimalsBySpeciesAsync(string speciesUrl)
        {
            var species = await _speciesService.GetSpeciesByUrlAsync(speciesUrl);
            return Animals.Where(x => x.SpeciesId == species.Id).ToList();
        }
    }
}
