using FluentValidation;
using Journal.Api.Models;

namespace Journal.Api.Validators
{
    public class JournalRequestValidator : AbstractValidator<JournalRequest>
    {
        public JournalRequestValidator()
        {
            RuleFor(r => r.Issn)
                .NotEmpty()
                .NotNull();

            RuleFor(r => r.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
