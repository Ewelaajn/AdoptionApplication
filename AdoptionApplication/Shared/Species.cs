using System.ComponentModel.DataAnnotations;

namespace AdoptionApplication.Shared
{
    public class Species
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Deleted { get; set; }
        public List<Animal> Animals { get; set; }
    }
}
