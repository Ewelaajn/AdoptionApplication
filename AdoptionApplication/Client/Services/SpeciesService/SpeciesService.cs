using AdoptionApplication.Shared;

namespace AdoptionApplication.Client.Services.SpeciesService
{
    public class SpeciesService : ISpeciesService
    {
        public ICollection<Species> Species { get ; set; } = new List<Species>();

        public void LoadSpecies()
        {
            Species = new List<Species>
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
        }
    }
}
