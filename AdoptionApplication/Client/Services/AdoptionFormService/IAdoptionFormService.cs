using AdoptionApplication.Shared;
using AdoptionApplication.Shared.DTO;

namespace AdoptionApplication.Client.Services.AdoptionFormService
{
    public interface IAdoptionFormService
    {
        Task<UserAdoptionForm> AddNewForm(UserAdoptionForm form);
        Task<UserAdoptionForm> ChangeStatus(UserAdoptionForm form);
        Task<BatchAdoptionForm> GetAllForms(int? page, string? email, int? animalId);
        Task<UserAdoptionForm> GetForm(int id);
    }
}
