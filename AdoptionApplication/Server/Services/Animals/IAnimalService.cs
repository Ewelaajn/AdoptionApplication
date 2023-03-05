using AdoptionApplication.Shared;
using AdoptionApplication.Shared.DTO;

namespace AdoptionApplication.Server.Services.Animals
{
    public interface IAnimalService
    {
        Task<BatchAnimal> GetAnimalsAsync(int? page);
        Task<BatchAnimal> GetAnimalsBySpeciesAsync(string speciesUrl, int? page);
        Task<Animal> GetAnimalByIdAsync(int id);
    }
}
