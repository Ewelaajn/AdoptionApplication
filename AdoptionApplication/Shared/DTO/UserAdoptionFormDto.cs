using AdoptionApplication.Shared.DbModels;

namespace AdoptionApplication.Shared.DTO
{
    public class UserAdoptionFormDto : BasicResponse
    {
        public int Id { get; set; }
        public Animal Animal { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Age { get; set; }
        public string AboutMe { get; set; }
        public string Status { get; set; }
    }
}
