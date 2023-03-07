using AdoptionApplication.Shared;

namespace AdoptionApplication.Client.Services.AnimalService
{
    public interface IAnimalService
    {
        event Action OnChange;
        ICollection<Animal> Animals { get; set; }
        public List<string> HealthStatuses { get; set; }
        public List<string> Genders { get; set; }
        Task<int> LoadAnimalsAsync(int? page, bool? isAdopted, string? city, string? province, string speciesUrl = null);
        Task<int> LoadAnimalsAsyncForAll(int? page, bool? isAdopted, string? city, string? province);
        Task<Animal> GetAnimalAsync(int id);
        Task<Animal> AddNewAnimal(Animal newAnimal);
    }
}
