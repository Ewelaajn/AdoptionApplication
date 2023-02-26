using AdoptionApplication.Shared;

namespace AdoptionApplication.Client.Services.AnimalService
{
    public interface IAnimalService
    {
        event Action OnChange;
        ICollection<Animal> Animals { get; set; }
        public List<string> HealthStatuses { get; set; }
        public List<string> Genders { get; set; }
        Task LoadAnimalsAsync(string speciesUrl = null);
        Task<Animal> GetAnimalAsync(int id);
    }
}
