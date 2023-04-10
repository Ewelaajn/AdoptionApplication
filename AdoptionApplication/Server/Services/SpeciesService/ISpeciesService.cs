using AdoptionApplication.Shared;
using AdoptionApplication.Shared.DbModels;

namespace AdoptionApplication.Server.Services.SpeciesService
{
    public interface ISpeciesService
    {
        public ICollection<Species> Species { get; set; }
        Task<ICollection<Species>> GetSpeciesAsync();
        Task<Species> GetSpeciesByUrlAsync(string speciesUrl);
        Task<Species> GetSingleSpeciesAsync(int id);
        Task<Species> UpsertNewSpecies(Species species);
        Task<Species> DeleteSpecies(int id);
    }
}
