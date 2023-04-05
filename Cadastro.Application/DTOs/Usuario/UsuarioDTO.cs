using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cadastro.Application.DTOs.Usuario
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "O campo name é obrigatório")]
        [JsonPropertyName("name")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo email é obrigatório")]
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("age")]
        public int Idade { get; set; }

        [JsonPropertyName("city")]
        public string Cidade { get; set; } = string.Empty;
    }
}
