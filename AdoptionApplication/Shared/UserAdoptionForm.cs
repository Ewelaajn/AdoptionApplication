using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdoptionApplication.Shared
{
    public partial class UserAdoptionForm
    {
        public string Id { get; set; } = null!;
        public int AnimalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Age { get; set; }
        public string AboutMe { get; set; }
        public string Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Deleted { get; set; }
    }
}
