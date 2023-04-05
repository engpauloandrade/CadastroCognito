using Cadastro.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Persistence.Persistencia
{
    public class PersistenciaEstatica<D> : IPersistenciaEstatica<D> where D : class
    {
        private IDataContext Ctx;
        private DbSet<D> DbSet;
        public PersistenciaEstatica(IDataContext ctx)
        {
            this.Ctx = ctx;
            this.DbSet = this.Ctx != null ? this.Ctx.Set<D>() : throw new ArgumentNullException("DbSet nulo");
        }

        public async Task<IEnumerable<D>> GetFiltroAsync(Expression<Func<D, bool>> expressaoDeConsulta,
            int page, int pageSize)
        {
            return await this.DbSet.Where(expressaoDeConsulta).Skip(page * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<D?> GetFiltroAsync(Expression<Func<D, bool>> expressaoDeConsulta)
        {
            return await this.DbSet.Where(expressaoDeConsulta).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<D>> GetAsync(int page, int pageSize)
        {
            return await this.DbSet.Skip(page * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
