using AdoptionApplication.Shared;

namespace AdoptionApplication.Server.Services.SpeciesService
{
    public interface ISpeciesService
    {
        public ICollection<Species> Species { get; set; }
        Task<ICollection<Species>> GetSpeciesAsync();
        Task<Species> GetSpeciesByUrlAsync(string speciesUrl);
        Task<Species> UpsertNewSpecies(Species species);
        Task DeleteSpecies(int id);
    }
}
