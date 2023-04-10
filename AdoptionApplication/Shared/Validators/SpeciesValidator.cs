using AdoptionApplication.Shared.DbModels;
using FluentValidation;

namespace AdoptionApplication.Shared.Validators
{
    public class SpeciesValidator : AbstractValidator<Species>
    {
        public SpeciesValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nazwa nie może być pusta");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url nie może być pusty");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Ikona nie może być pusta");
        }
    }
}
