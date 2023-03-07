using FluentValidation;

namespace AdoptionApplication.Shared.Validators
{
    public class AnimalValidator : AbstractValidator<Animal>
    {
        public AnimalValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.ShortDescription).NotEmpty();
            RuleFor(x => x.HealthStatus).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Province).NotEmpty();
            RuleFor(x => x.Image).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.AdoptionDate).NotEmpty();
            RuleFor(x => x.AdoptionDate).GreaterThan(x => x.DateOfBirth);
            RuleFor(x => x.SpeciesId).NotEmpty();
        }
    }
}
