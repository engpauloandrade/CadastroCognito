using AutoMapper;
using Cadastro.Application.DTOs.Usuario;
using Cadastro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Application.Mappings
{
    public class MapeadorDTO : Profile
    {
        public MapeadorDTO() : base()
        {
            MapeamentoUsuario();
        }
        private void MapeamentoUsuario()
        {
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
        }
    }
}
