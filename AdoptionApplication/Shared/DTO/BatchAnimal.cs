namespace AdoptionApplication.Shared.DTO
{
    public class BatchAnimal : BasicResponse
    {
        public ICollection<Animal> Animals { get; set; }
        public int Total { get; set; }
    }
}
