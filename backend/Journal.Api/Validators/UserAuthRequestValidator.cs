using FluentValidation;
using Journal.Api.Controllers;
using Journal.Api.Models;
using Journal.Api.Repositories;

namespace Journal.Api.Validators
{
    public class UserAuthRequestValidator : AbstractValidator<UserAuthRequest>
    {
        public UserAuthRequestValidator(IUserRepository userRepository)
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(9);
        }
    }
}