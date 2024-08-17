using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoLivrosAPI.DTOs {

    public class UsuarioDTO {

        public required string Nome { get; set; }

        public required string Email { get; set; }

        [NotMapped]
        public required string Password { get; set; }
    }
}