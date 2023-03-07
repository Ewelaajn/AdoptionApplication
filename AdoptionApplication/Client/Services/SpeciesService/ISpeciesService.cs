using AdoptionApplication.Shared;

namespace AdoptionApplication.Client.Services.SpeciesService
{
    public interface ISpeciesService
    {
        public ICollection<Species> Species { get; set; }

        Task LoadSpecies();
        Task<Species> UpsertSpecies(Species species);
        Task<Species> GetSpecies(int id);
        Task DeleteSpecies(int id);
    }
}
