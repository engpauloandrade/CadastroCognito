using Cadastro.Application.Contracts;
using Cadastro.Application.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Cadastro.Controllers
{
    [ApiController]
    [Route("cadastros/v1/")]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioService usuario;    


        public UsuarioController(IUsuarioService usuario)
        {
            this.usuario = usuario;
        }


        [HttpPost]
        [Route("user/insert")]
        public async Task<IActionResult> PostJuridico([FromBody] UsuarioDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dtoList = new List<UsuarioDTO> { model };
                    return StatusCode((int)HttpStatusCode.Created, new { data = await this.usuario.PostUsuario(dtoList) });
                }

                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }       
}
