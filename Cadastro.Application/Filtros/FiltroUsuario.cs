using Cadastro.Application.Contracts;
using Cadastro.Application.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Filters
{
    public class FiltroUsuario : IFiltro<UsuarioDTO>
    {
        public string? Email { get; set; }

        public UsuarioDTO? Dado()
        {
            UsuarioDTO usuario = new();

            if (!string.IsNullOrEmpty(this.Email))
            {
                usuario.Email = this.Email;
            }
            return usuario;
        }
    }
}
