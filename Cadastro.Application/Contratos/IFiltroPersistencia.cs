using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Contracts
{
    public interface IFiltroPersistencia<DTO, D>
        where D : class
        where DTO : class
    {
        public Expression<Func<D, bool>> CriaExpressao(DTO? dado);
    }
}
