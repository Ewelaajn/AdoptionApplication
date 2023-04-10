using AdoptionApplication.Shared;
using AdoptionApplication.Shared.DbModels;
using AdoptionApplication.Shared.DTO;

namespace AdoptionApplication.Server.Services.Animals
{
    public interface IAnimalService
    {
        Task<BatchAnimal> GetAnimalsAsync(int? page, bool? isAdopted, string? city, string? province);
        Task<BatchAnimal> GetAnimalsBySpeciesAsync(string speciesUrl, int? page, bool? isAdopted, string? city, string? province);
        Task<Animal> GetAnimalByIdAsync(int id);
        Task<Animal> UpsertAnimalAsync(Animal animal);
        Task DeleteAnimal(int id);
    }
}
