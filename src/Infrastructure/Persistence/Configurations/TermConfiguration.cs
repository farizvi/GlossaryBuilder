using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GlossaryBuilder.Domain.Entities;

namespace GlossaryBuilder.Infrastructure.Persistence.Configurations
{
    public class TermConfiguration : IEntityTypeConfiguration<Term>
    {
        public void Configure(EntityTypeBuilder<Term> builder)
        {
            builder.Property(t => t.TermText)
                .HasMaxLength(20)
                .IsRequired();
            
            builder.Property(t => t.Definition)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}