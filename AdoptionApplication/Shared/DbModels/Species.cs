using System.ComponentModel.DataAnnotations.Schema;
using AdoptionApplication.Shared.DTO;

namespace AdoptionApplication.Shared.DbModels
{
    public class Species: BasicResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Deleted { get; set; }
        [NotMapped]
        public virtual List<Animal?>? Animals { get; set; }
    }
}
