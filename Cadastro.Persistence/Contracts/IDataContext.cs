using Cadastro.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Persistence.Contracts
{
    public interface IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet<Usuario> Usuario { get; set; }
    }
}
