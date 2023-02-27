using FluentValidation;

namespace AdoptionApplication.Shared.Validators
{
    public class SpeciesValidator : AbstractValidator<Species>
    {
        public SpeciesValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Url).NotEmpty();
            RuleFor(x => x.Icon).NotEmpty();
        }
    }
}
