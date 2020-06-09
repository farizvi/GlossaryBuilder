using System;
using System.Collections.Generic;
using GlossaryBuilder.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace GlossaryBuilder.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Terms.Any())
            {
                var terms = new List<Term>
                {
                    new Term
                    {
                        TermText = "abyssal plain",
                        Definition = "The ocean floor offshore from the continental margin, usually very flat with a slight slope.",
                        Created = DateTime.Now
                    },
                    new Term
                    {
                        TermText = "accrete",
                        Definition = "v. To add terranes (small land masses or pieces of crust) to another, usually larger, land mass.",
                        Created = DateTime.Now
                    },
                    new Term
                    {
                        TermText = "alkaline",
                        Definition = "Term pertaining to a highly basic, as opposed to acidic, subtance. For example, hydroxide or carbonate of sodium or potassium.",
                        Created = DateTime.Now
                    }
                };
                
                await context.Terms.AddRangeAsync(terms);
                await context.SaveChangesAsync();
            }
        }
    }
}
