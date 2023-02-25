using AdoptionApplication.Server.Services.SpeciesService;
using AdoptionApplication.Shared;

namespace AdoptionApplication.Server.Services.SpeciesService
{
    public class SpeciesService : ISpeciesService
    {
        public ICollection<Species> Species { get ; set ; } = new List<Species>
            {
                new Species
                {
                    Id = 1,
                    Name = "Króliki",
                    Url = "rabbits",
                    Icon = "fa-solid fa-carrot",
                    CreateDate = DateTime.UtcNow,
                    Deleted = false
                },
                new Species
                {
                    Id = 2,
                    Name = "Psy",
                    Url = "dogs",
                    Icon = "fas fa-dog",
                    CreateDate = DateTime.UtcNow,
                    Deleted = false
                },
                new Species
                {
                    Id = 3,
                    Name = "Koty",
                    Url = "cats",
                    Icon = "fas fa-cat",
                    CreateDate = DateTime.UtcNow,
                    Deleted = false
                }
            };

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
