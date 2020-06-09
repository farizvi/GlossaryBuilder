using System.Threading;
using System.Threading.Tasks;
using MediatR;
using GlossaryBuilder.Application.Common.Exceptions;
using GlossaryBuilder.Application.Common.Interfaces;

namespace GlossaryBuilder.Application.Term.Commands.DeleteTerm
{
    public class DeleteTermCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTermCommandHandler : IRequestHandler<DeleteTermCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTermCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(DeleteTermCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Terms.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Term), request.Id);
            }

            _context.Terms.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}