namespace Cadastro.Persistence.Contracts
{
    public interface IPersistenciaDinamica<D> where D : class
    {
        public Task<IEnumerable<D>> PostAsync(IEnumerable<D> model);
    }
}
