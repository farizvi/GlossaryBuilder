using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using GlossaryBuilder.Application.Common.Interfaces;

namespace GlossaryBuilder.Application.Term.Commands.CreateTerm
{
    public class CreateTermCommand : IRequest<CreatedTermVM>
    {
        public string TermText { get; set; }

        public string Definition { get; set; }
    }

    public class CreateTermCommandHandler : IRequestHandler<CreateTermCommand, CreatedTermVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateTermCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreatedTermVM> Handle(CreateTermCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Term
            {
                TermText = request.TermText,
                Definition = request.Definition,
            };

            await _context.Terms.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return new CreatedTermVM
            {
                Id = entity.Id,
                TermText = entity.TermText,
                Definition = entity.Definition,
                Created = entity.Created
            };
        }
    }
}