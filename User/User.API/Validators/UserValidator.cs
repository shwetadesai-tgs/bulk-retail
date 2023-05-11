using FluentValidation;
using User.Core.Models;

namespace User.API.Validators
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName)
                    .NotNull()
                    .NotEmpty().WithMessage("Please add a name");
            RuleFor(s => s.Email)
                    .NotEmpty().WithMessage("Email address is required")
                    .EmailAddress().WithMessage("A valid email is required");
            RuleFor(p => p.Phone)
                    .NotEmpty()
                    .NotNull().WithMessage("Phone Number is required.")
                    .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
                    .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.");
        }
    }
}
