using AdoptionApplication.Shared;
using AdoptionApplication.Shared.Constants;
using AdoptionApplication.Shared.DTO;
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
        public async Task<Animal?> AddNewAnimal(Animal? newAnimal)
        {
            var result = await _httpClient.PutAsJsonAsync("api/Animal", newAnimal);
            var animalResult = await JsonSerializer.DeserializeAsync<Animal>(await result.Content.ReadAsStreamAsync());
             return animalResult;
        }

        public async Task DeleteAnimal(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Animal/{id}");
            if (!result.IsSuccessStatusCode)
                throw new Exception(result.ReasonPhrase);
        }

        public async Task<Animal?> GetAnimalAsync(int id)
        => await _httpClient.GetFromJsonAsync<Animal>($"api/Animal/{id}");

        public async Task<int> LoadAnimalsAsync(int? page, bool? isAdopted, string? city, string? province, string speciesUrl = null)
        {
            BatchAnimal? result;
            if (string.IsNullOrEmpty(speciesUrl))
            {
                result = await _httpClient.GetFromJsonAsync<BatchAnimal>($"api/Animal?page={page}&isAdopted={isAdopted}&city={city}&province={province}");
                Animals = result?.Animals ?? new List<Animal>();
            }
            else
            {
                result = await _httpClient.GetFromJsonAsync<BatchAnimal>($"api/Animal/Species/{speciesUrl}?page={page}&isAdopted={isAdopted}&city={city}&province={province}");
                Animals = result?.Animals ?? new List<Animal>();
            }
                
            OnChange.Invoke();
            return result?.Total ?? 0;
        }

        public async Task<int> LoadAnimalsAsyncForAll(int? page, bool? isAdopted, string? city, string? province)
        {
            var result = await _httpClient.GetFromJsonAsync<BatchAnimal>($"api/Animal?page={page}&isAdopted={isAdopted}&city={city}&province={province}");
            Animals = result?.Animals ?? new List<Animal>();
            
            return result?.Total ?? 0;
        }
    }
}
