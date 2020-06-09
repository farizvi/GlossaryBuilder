using System;
using GlossaryBuilder.Application.Common.Mappings;

namespace GlossaryBuilder.Application.Term.Commands.CreateTerm
{
    public class CreatedTermVM: IMapFrom<Domain.Entities.Term>
    {
        public int Id { get; set; }

        public string TermText { get; set; }

        public string Definition { get; set; }

        public DateTime Created { get; set; }
    }
}