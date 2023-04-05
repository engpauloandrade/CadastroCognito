using Cadastro.Application.Contracts;
using Cadastro.Application.DTOs.Usuario;
using Cadastro.Application.Filters.Persistencias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Filters
{
    public class ConstroiIFiltro<DTO, D>
       where DTO : class
       where D : class
    {
        public static Expression<Func<D, bool>>? GetFiltro(DTO? dado)
        {
            IFiltroPersistencia<DTO, D>? filter = DecideFiltro(dado);
            if (filter != null)
            {
                return filter.CriaExpressao(dado);
            }
            return null;
        }


        private static IFiltroPersistencia<DTO, D>? DecideFiltro(DTO? dado)
        {
            if (dado != null)
            {
                if (dado.GetType() == typeof(UsuarioDTO))
                {
                    return (IFiltroPersistencia<DTO, D>)new FiltroPersistenciaUsuario();
                }
            }
            return null;
        }
    }
}
