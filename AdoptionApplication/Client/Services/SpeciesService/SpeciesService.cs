using AdoptionApplication.Shared;
using System.Net.Http.Json;

namespace AdoptionApplication.Client.Services.SpeciesService
{
    public class SpeciesService : ISpeciesService
    {
        public ICollection<Species> Species { get ; set; } = new List<Species>();

        private readonly HttpClient _httpClient;

        public SpeciesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task LoadSpecies()
        {
            Species = await _httpClient.GetFromJsonAsync<ICollection<Species>>("api/Species");
        }
    }
}
