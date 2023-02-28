using AdoptionApplication.Shared;
using AdoptionApplication.Shared.Constants;
using System.Net.Http.Json;
using System.Text.Json;

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
        public List<string> HealthStatuses { get; set; } = new List<string> { HealthStatusContants.Healthy, HealthStatusContants.Unhealthy};
        public List<string> Genders { get; set; } = new List<string> { GenderContants.Male, GenderContants.Female, GenderContants.Undefined };

        public event Action OnChange;

        public async Task<Animal> AddNewAnimal(Animal newAnimal)
        {
            var result = await _httpClient.PutAsJsonAsync("api/Animal", newAnimal);

            if (!result.IsSuccessStatusCode)
                return null;
            else
            {
                var animalResult = await JsonSerializer.DeserializeAsync<Animal>(await result.Content.ReadAsStreamAsync());
                return animalResult;
            }
        }

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
