using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.Application.DTOs {

    public class ClienteDTO {
        
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O campo 'nome' deve ter no mínimo 5 caracteres")]
        public required string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um email válido...")]
        public required string Email { get; set; }

        [RegularExpression(@"^\([1-9]{2}\) (9[0-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "Informe um telefone válido...")]
        public required string Telefone { get; set; }
    }
}