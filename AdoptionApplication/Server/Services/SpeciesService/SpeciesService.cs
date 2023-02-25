using AdoptionApplication.Server.Services.SpeciesService;
using AdoptionApplication.Shared;

namespace AdoptionApplication.Server.Services.SpeciesService
{
    public class SpeciesService : ISpeciesService
    {
        public ICollection<Species> Species { get; set; } = new List<Species>();

        public async Task<ICollection<Species>> GetSpeciesAsync()
        {
            return Species;
        }

        public async Task<Species> GetSpeciesByUrlAsync(string speciesUrl)
        {
            return Species.FirstOrDefault(x => x.Url.ToLower() == speciesUrl.ToLower());
        }
    }
}
