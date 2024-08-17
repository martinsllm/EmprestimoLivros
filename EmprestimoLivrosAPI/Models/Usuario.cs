using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivrosAPI.Models {

    public class Usuario {
        
        [Key]
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Email { get; set; }

        [MinLength(6)]
        [MaxLength(12)]
        public required string Password { get; set; }
    }
}