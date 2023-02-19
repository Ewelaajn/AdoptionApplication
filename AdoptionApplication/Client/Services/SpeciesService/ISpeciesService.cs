using AdoptionApplication.Shared;

namespace AdoptionApplication.Client.Services.SpeciesService
{
    public interface ISpeciesService
    {
        public ICollection<Species> Species { get; set; }

        void LoadSpecies();
    }
}
