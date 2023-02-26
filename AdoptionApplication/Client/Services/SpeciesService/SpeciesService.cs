using AdoptionApplication.Shared;
using System.Net.Http.Json;
using System.Text.Json;

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

        public async Task<Species> UpsertSpecies(int? id, Species species)
        {
            HttpResponseMessage result;
            if(id != null)
                result = await _httpClient.PutAsJsonAsync<Species>($"api/Species/{id}", species);
            else
                result = await _httpClient.PostAsJsonAsync<Species>($"api/Species", species);

            if (!result.IsSuccessStatusCode)
                return null;
            else
            {
                var speciesResult = await JsonSerializer.DeserializeAsync<Species>(await result.Content.ReadAsStreamAsync());
                return speciesResult;
            }
        }
    }
}
