using System.ComponentModel.DataAnnotations.Schema;
using AdoptionApplication.Shared.DTO;

namespace AdoptionApplication.Shared.DbModels
{
    public class UserAdoptionForm: BasicResponse
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
