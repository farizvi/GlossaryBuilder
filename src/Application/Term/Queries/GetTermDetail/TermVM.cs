using System;
using GlossaryBuilder.Application.Common.Mappings;

namespace GlossaryBuilder.Application.Term.Queries.GetTermDetail
{
    public class TermVM : IMapFrom<Domain.Entities.Term>
    {
        public int Id { get; set; }

        public string TermText { get; set; }

        public string Definition { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }
    }
}