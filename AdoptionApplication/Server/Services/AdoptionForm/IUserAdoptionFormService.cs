using AdoptionApplication.Shared;

namespace AdoptionApplication.Server.Services.AdoptionForm
{
    public interface IUserAdoptionFormService
    {
        Task<ICollection<UserAdoptionForm>> GetUserAdoptionFormsAsync();
        Task<UserAdoptionForm> GetUserAdoptionFormAsync(int id);
        Task<UserAdoptionForm> ChangeFormStatus(int formId, string status);
        Task<UserAdoptionForm> AddNewForm(UserAdoptionForm newForm);
        Task DeleteForm(int id);
    }
}
