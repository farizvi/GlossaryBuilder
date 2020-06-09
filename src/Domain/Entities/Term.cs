using GlossaryBuilder.Domain.Common;

namespace GlossaryBuilder.Domain.Entities
{
    public class Term : AuditableEntity
    {
        public int Id { get; set; }
        
        public string TermText { get; set; }

        public string Definition { get; set; }
    }
}