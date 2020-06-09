using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using GlossaryBuilder.Application.Common.Interfaces;

namespace GlossaryBuilder.Application.Term.Queries.GetTerms
{
    public class GetTermsQuery : IRequest<TermsVM>
    {
    }

    public class GetTermsQueryHandler : IRequestHandler<GetTermsQuery, TermsVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTermsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<TermsVM> Handle(GetTermsQuery request, CancellationToken cancellationToken)
        {
            return new TermsVM
            {
                Terms = await _context.Terms
                    .ProjectTo<TermsDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.TermText)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}