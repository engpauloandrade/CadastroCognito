using System.Linq.Expressions;

namespace Cadastro.Persistence.Contracts
{
    public interface IPersistenciaEstatica<D>
    {
        Task<IEnumerable<D>> GetAsync(int page, int pageSize);
        Task<IEnumerable<D>> GetFiltroAsync(Expression<Func<D, bool>> expressaoDeConsulta,
            int page, int pageSize);
        Task<D> GetFiltroAsync(Expression<Func<D, bool>> expressaoDeConsulta);
    }
}
