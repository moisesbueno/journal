using FluentValidation;
using Journal.Api.Controllers;
using Journal.Api.Models;
using Journal.Api.Repositories;

namespace Journal.Api.Validators
{
    public class UserAddRequestValidator : AbstractValidator<UserAddRequest>
    {
        public UserAddRequestValidator(IUserRepository userRepository)
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(email =>
                {
                    return !userRepository.Exists(email);
                }).WithMessage("User already exists");

            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(9);

            RuleFor(r => new { r.Password, r.PasswordVerification })
               .Custom((data, context) =>
               {
                   if (data.Password != data.PasswordVerification)
                   {
                       context.AddFailure("PasswordVerification", "PasswordVerifiction incorrect");
                   }
               });
        }
    }
}