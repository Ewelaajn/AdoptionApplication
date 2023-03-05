using AdoptionApplication.Shared;

namespace AdoptionApplication.Server.Services.Animals
{
    public interface IAnimalService
    {
        ICollection<Animal> Animals { get; set; }
        Task<ICollection<Animal>> GetAnimalsAsync();
        Task<ICollection<Animal>> GetAnimalsBySpeciesAsync(string speciesUrl);
        Task<Animal> GetAnimalByIdAsync(int id);
        Task<Animal> UpsertAnimalAsync(Animal animal);
    }
}
