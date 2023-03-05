using AdoptionApplication.Shared;

namespace AdoptionApplication.Client.Services.AnimalService
{
    public interface IAnimalService
    {
        event Action OnChange;
        ICollection<Animal> Animals { get; set; }
        public List<string> HealthStatuses { get; set; }
        public List<string> Genders { get; set; }
        Task<int> LoadAnimalsAsync(int? page, string speciesUrl = null);
        Task<int> LoadAnimalsAsyncForAll(int? page);
        Task<Animal> GetAnimalAsync(int id);
    }
}
