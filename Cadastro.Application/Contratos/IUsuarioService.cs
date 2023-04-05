using Cadastro.Application.DTOs.Usuario;

namespace Cadastro.Application.Contracts
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> PostUsuario(List<UsuarioDTO> dto);
    }
}
