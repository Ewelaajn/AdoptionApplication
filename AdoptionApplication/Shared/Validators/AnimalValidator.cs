using FluentValidation;

namespace AdoptionApplication.Shared.Validators
{
    public class AnimalValidator : AbstractValidator<Animal>
    {
        public AnimalValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Imię nie może być pust3e");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Opis musi być wypełniony");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Należy wybrać płeć zwierzęcia");
            RuleFor(x => x.ShortDescription).NotEmpty().WithMessage("Należy wypełnić krótki opis");
            RuleFor(x => x.HealthStatus).NotEmpty().WithMessage("Należy wybrać status zdrowia zwierzęcia");
            RuleFor(x => x.City).NotEmpty().WithMessage("Miasto nie może być puste");
            RuleFor(x => x.Province).NotEmpty().WithMessage("Województwo nie może być puste");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Zdjęcie nie może być puste");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Należy podać przybliżoną datę urodzenia zwierzęcia");
            When(x => x.IsAdopted == true, 
                () => RuleFor(x => x.AdoptionDate).NotEmpty().WithMessage("Należy podać datę adopcji zwierzęcia"));
            When(x => x.IsAdopted == true, 
                () => RuleFor(x => x.AdoptionDate).GreaterThan(x => x.DateOfBirth)
                .WithMessage("Data adopcji musi być większa niż data urodzenia"));
            RuleFor(x => x.SpeciesId).NotEmpty();
        }
    }
}
