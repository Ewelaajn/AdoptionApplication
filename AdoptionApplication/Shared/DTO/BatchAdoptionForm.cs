namespace AdoptionApplication.Shared.DTO;

public class BatchAdoptionForm
{
    public int Total { get; set; }
    public ICollection<UserAdoptionForm> AdoptionForms { get; set; }
}