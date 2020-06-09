using FluentValidation;

namespace GlossaryBuilder.Application.Term.Commands.UpdateTerm
{
    public class UpdateTermCommandValidator: AbstractValidator<UpdateTermCommand>
    {
        public UpdateTermCommandValidator()
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