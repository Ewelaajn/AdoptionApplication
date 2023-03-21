using AdoptionApplication.Shared;
using System.Net.Http.Json;
using System.Text.Json;

namespace AdoptionApplication.Client.Services.SpeciesService
{
    public class SpeciesService : ISpeciesService
    {
        public ICollection<Species>? Species { get ; set; } = new List<Species>();

        private readonly HttpClient _httpClient;

        public SpeciesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task LoadSpecies()
        {
            Species = await _httpClient.GetFromJsonAsync<ICollection<Species>>("api/Species");
        }

        public async Task<Species?> UpsertSpecies(Species? species)
        {
            var result = await _httpClient.PutAsJsonAsync("api/Species", species);
            var speciesResult = await JsonSerializer.DeserializeAsync<Species>(await result.Content.ReadAsStreamAsync());
            return speciesResult;
        }

        public async Task<Species?> GetSpecies(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Species>($"api/Species/{id}");
            return result;
        }

        public async Task<Species?> DeleteSpecies(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Species/{id}");
            var speciesResult = await JsonSerializer.DeserializeAsync<Species>(await result.Content.ReadAsStreamAsync());
            return speciesResult;
        }
    }
}
