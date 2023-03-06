namespace AdoptionApplication.Shared.DTO
{
    public class BatchAnimal
    {
        public ICollection<Animal> Animals { get; set; }
        public int Total { get; set; }
    }
}
