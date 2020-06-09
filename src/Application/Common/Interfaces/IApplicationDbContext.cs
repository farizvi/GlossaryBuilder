using GlossaryBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GlossaryBuilder.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Term> Terms { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
