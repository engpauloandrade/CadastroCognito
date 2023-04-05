using Cadastro.Application.Contracts;
using Cadastro.Application.DTOs.Usuario;
using Cadastro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Filters.Persistencias
{
    public class FiltroPersistenciaUsuario : IFiltroPersistencia<UsuarioDTO, Usuario>
    {
        public Expression<Func<Usuario, bool>> CriaExpressao(UsuarioDTO? dado)
        {
            if (dado != null)
            {
                if (!string.IsNullOrEmpty(dado.Email))
                {
                    return p => p.Email.Equals(dado.Email);
                }
                else if (!string.IsNullOrEmpty(dado.Nome))
                {
                    return p => p.Nome.Equals(dado.Nome);
                }
            };
            return null;
        }
    }
}
