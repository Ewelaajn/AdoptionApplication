using System.ComponentModel.DataAnnotations.Schema;

namespace AdoptionApplication.Shared
{
    public class Animal
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsAdopted { get; set; }
        public string? Gender { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? HealthStatus { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Image { get; set; } = "https://via.placeholder.com/300x300";
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? AdoptionDate { get; set; }
        public bool? Deleted { get; set; }
        public Species? Species { get; set; }
        public int SpeciesId { get; set; }
    }
}
