using AdoptionApplication.Shared;
using AdoptionApplication.Shared.DbModels;
using AdoptionApplication.Shared.DTO;

namespace AdoptionApplication.Server.Services.AdoptionForm
{
    public interface IUserAdoptionFormService
    {
        Task<BatchAdoptionForm> GetUserAdoptionFormsAsync(int? page, string? email, int? animalId, string status);
        Task<UserAdoptionForm> GetUserAdoptionFormAsync(int id);
        Task<UserAdoptionForm> ChangeFormStatus(int formId, string status);
        Task<UserAdoptionForm> UpsertUserForm(UserAdoptionForm newForm);
    }
}
