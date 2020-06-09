using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using GlossaryBuilder.Application.Common.Exceptions;
using GlossaryBuilder.Application.Common.Interfaces;

namespace GlossaryBuilder.Application.Term.Queries.GetTermDetail
{
    public class GetTermDetailQuery : IRequest<TermVM>
    {
        public int Id { get; set; }
    }

    public class GetTermDetailQueryHandler : IRequestHandler<GetTermDetailQuery, TermVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTermDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<TermVM> Handle(GetTermDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Terms
                .ProjectTo<TermVM>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync<TermVM>(l => l.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Term), request.Id);
            }

            return entity;
        }
    }
}