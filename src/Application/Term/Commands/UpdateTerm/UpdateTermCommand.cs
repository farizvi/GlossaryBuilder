using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GlossaryBuilder.Application.Common.Exceptions;
using GlossaryBuilder.Application.Common.Interfaces;

namespace GlossaryBuilder.Application.Term.Commands.UpdateTerm
{
    public partial class UpdateTermCommand : IRequest
    {
        public int Id { get; set; }

        public string TermText { get; set; }

        public string Definition { get; set; }
    }

    public class UpdateTermCommandHandler : IRequestHandler<UpdateTermCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTermCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(UpdateTermCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Terms.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Term), request.Id);
            }

            entity.TermText = request.TermText;
            entity.Definition = request.Definition;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}