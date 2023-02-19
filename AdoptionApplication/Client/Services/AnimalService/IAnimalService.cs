using AdoptionApplication.Shared;

namespace AdoptionApplication.Client.Services.AnimalService
{
    public interface IAnimalService
    {
        ICollection<Animal> Animals { get; set; }
        void LoadAnimals();
    }
}
