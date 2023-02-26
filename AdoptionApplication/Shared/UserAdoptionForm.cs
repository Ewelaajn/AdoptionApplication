using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoptionApplication.Shared
{
    public partial class UserAdoptionForm
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Animal))]
        public int AnimalId { get; set; }
        public Animal? Animal { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Age { get; set; }
        public string? AboutMe { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Deleted { get; set; }
    }
}
