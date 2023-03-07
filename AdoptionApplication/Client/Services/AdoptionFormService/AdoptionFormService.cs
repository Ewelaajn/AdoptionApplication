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

        public async Task<UserAdoptionForm> AddNewForm(UserAdoptionForm form)
        {
            var result = await _httpClient.PutAsJsonAsync("api/AdoptionForm", form);
            switch (result.StatusCode)
            {
                case System.Net.HttpStatusCode.NotFound or System.Net.HttpStatusCode.BadRequest:
                    return null;
                default:
                {
                    UserAdoptionForm? userAdoptionForm = await JsonSerializer.DeserializeAsync<UserAdoptionForm>(await result.Content.ReadAsStreamAsync());
                    return userAdoptionForm;
                }
            }
        }

        public Task<UserAdoptionForm> ChangeStatus(UserAdoptionForm form)
        {
            throw new NotImplementedException();
        }

        public Task<BatchAdoptionForm> GetAllForms(int? page, string? email, int? animalId)
        {
            throw new NotImplementedException();
        }

        public Task<UserAdoptionForm> GetForm(int id)
        {
            throw new NotImplementedException();
        }
    }
}
