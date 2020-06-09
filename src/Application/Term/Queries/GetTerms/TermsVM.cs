using System.Collections.Generic;
using GlossaryBuilder.Application.Common.Mappings;

namespace GlossaryBuilder.Application.Term.Queries.GetTerms
{
    public class TermsVM : IMapFrom<Domain.Entities.Term>
    {
        public IList<TermsDto> Terms { get; set; }
    }
}