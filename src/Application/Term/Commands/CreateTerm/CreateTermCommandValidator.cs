using FluentValidation;

namespace GlossaryBuilder.Application.Term.Commands.CreateTerm
{
    public class CreateTermCommandValidator : AbstractValidator<CreateTermCommand>
    {
        public CreateTermCommandValidator()
        {
            RuleFor(t => t.TermText)
                .MaximumLength(20)
                .NotEmpty();

            RuleFor(t => t.Definition)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}