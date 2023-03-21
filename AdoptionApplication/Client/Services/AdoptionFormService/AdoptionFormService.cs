using AdoptionApplication.Shared;
using System.Net.Http.Json;
using System.Text.Json;
using AdoptionApplication.Shared.DTO;

namespace AdoptionApplication.Client.Services.AdoptionFormService
{
    public class AdoptionFormService : IAdoptionFormService
    {
        private readonly HttpClient _httpClient;

        public AdoptionFormService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ICollection<UserAdoptionForm> AdoptionForms { get; set; } = new List<UserAdoptionForm>();

        public async Task<UserAdoptionForm?> AddNewForm(UserAdoptionForm form)
        {
            var result = await _httpClient.PutAsJsonAsync("api/AdoptionForm", form);
            UserAdoptionForm? userAdoptionForm = await JsonSerializer.DeserializeAsync<UserAdoptionForm>(await result.Content.ReadAsStreamAsync());
            return userAdoptionForm;
        }

        public async Task<UserAdoptionForm?> ChangeStatus(UserAdoptionForm? form)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/AdoptionForm/status", form);
            var formStatusResult = await JsonSerializer.DeserializeAsync<UserAdoptionForm>(await result.Content.ReadAsStreamAsync());
            return formStatusResult;
        }

        public async Task<int> GetAllForms(int? page, string? email, int? animalId, string status)
        {
            var  result = await _httpClient.GetFromJsonAsync<BatchAdoptionForm>(
                $"api/AdoptionForm?page={page}&email={email}&animalId={animalId}&status={status}");
            AdoptionForms = result?.AdoptionForms ?? new List<UserAdoptionForm>();

            return result?.Total ?? 0;
        }

        public async Task<UserAdoptionForm?> GetForm(int id)
        {
            return await _httpClient.GetFromJsonAsync<UserAdoptionForm>($"api/AdoptionForm/{id}");
        }
    }
}
