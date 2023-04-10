using AdoptionApplication.Shared.DbModels;

namespace AdoptionApplication.Shared.DTO;

public class BatchAdoptionForm : BasicResponse
{
    public int Total { get; set; }
    public ICollection<UserAdoptionForm> AdoptionForms { get; set; }
}