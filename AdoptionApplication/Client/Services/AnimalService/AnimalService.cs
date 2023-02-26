using AdoptionApplication.Shared;
using System.Net.Http.Json;

namespace AdoptionApplication.Client.Services.AnimalService
{
    public class AnimalService : IAnimalService
    {
        private readonly HttpClient _httpClient;

        public AnimalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ICollection<Animal> Animals { get ; set; } = new List<Animal>();

        public event Action OnChange;

        public async Task<Animal> GetAnimalAsync(int id)
        => await _httpClient.GetFromJsonAsync<Animal>($"api/Animal/{id}");

        public async Task LoadAnimalsAsync(string speciesUrl = null)
        {
            if (string.IsNullOrEmpty(speciesUrl))
                Animals = await _httpClient.GetFromJsonAsync<ICollection<Animal>>($"api/Animal");
            else
                Animals = await _httpClient.GetFromJsonAsync<ICollection<Animal>>($"api/Animal/Species/{speciesUrl}");

            OnChange.Invoke();
        }
    }
}
