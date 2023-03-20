using FluentValidation;

namespace AdoptionApplication.Shared.Validators
{
    public class UserAdoptionFormValidator : AbstractValidator<UserAdoptionForm>
    {
        public UserAdoptionFormValidator()
        {
            RuleFor(x => x.AnimalId).NotNull().NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Imię nie może być puste");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Nazwisko nie może być puste");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email musi być w prawidłowym formacie");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Numer telefonu nie może być pusty");
            RuleFor(x => x.Age).GreaterThan("18").NotEmpty().WithMessage("Wiek musi być większy niż 18");
            RuleFor(x => x.AboutMe).NotEmpty().WithMessage("Należy podać kilka zdań o sobie");
        }
    }
}
