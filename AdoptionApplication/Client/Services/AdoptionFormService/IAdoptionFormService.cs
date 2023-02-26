using AdoptionApplication.Shared;

namespace AdoptionApplication.Client.Services.AdoptionFormService
{
    public interface IAdoptionFormService
    {
        Task<UserAdoptionForm> AddNewForm(UserAdoptionForm form);
    }
}
