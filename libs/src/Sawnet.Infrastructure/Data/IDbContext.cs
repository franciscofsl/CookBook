using Microsoft.EntityFrameworkCore;

namespace Sawnet.Infrastructure.Data;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
