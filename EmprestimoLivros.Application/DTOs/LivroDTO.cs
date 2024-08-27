using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.Application.DTOs {

    public class LivroDTO {
        
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O campo 'nome' deve ter no mínimo 5 caracteres")]
        public required string Nome { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "O campo 'autor' deve ter no mínimo 5 caracteres")]
        public required string Autor { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo 'editora' deve ter no mínimo 3 caracteres")]
        public required string Editora { get; set; }

        public required string AnoPublicacao { get; set; }
    }
}