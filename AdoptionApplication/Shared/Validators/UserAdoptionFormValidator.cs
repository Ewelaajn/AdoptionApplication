using FluentValidation;

namespace AdoptionApplication.Shared.Validators
{
    public class UserAdoptionFormValidator : AbstractValidator<UserAdoptionForm>
    {
        public UserAdoptionFormValidator()
        {
            RuleFor(x => x.Animal).NotNull().NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Age).NotEmpty();
            RuleFor(x => x.AboutMe).NotEmpty();
        }
    }
}
