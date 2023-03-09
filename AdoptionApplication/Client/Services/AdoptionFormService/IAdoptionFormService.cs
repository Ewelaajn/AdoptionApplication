using AdoptionApplication.Shared;

namespace AdoptionApplication.Client.Services.AdoptionFormService
{
    public interface  IAdoptionFormService
    {
        public ICollection<UserAdoptionForm> AdoptionForms { get; set; }
        Task<UserAdoptionForm> AddNewForm(UserAdoptionForm form);
        Task<UserAdoptionForm> ChangeStatus(UserAdoptionForm form);
        Task<int> GetAllForms(int? page, string? email, int? animalId, string status);
        Task<UserAdoptionForm> GetForm(int id);
    }
}
