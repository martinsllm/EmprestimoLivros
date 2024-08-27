using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoLivros.Application.DTOs {

    public class UsuarioDTO {

        [StringLength(50, MinimumLength = 5, ErrorMessage = "O campo 'nome' deve ter no mínimo 5 caracteres")]
        public required string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um email válido...")]
        public required string Email { get; set; }

        [NotMapped]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 12 caracteres")]
        public required string Password { get; set; }
    }
}