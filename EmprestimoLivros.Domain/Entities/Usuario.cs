using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.Domain.Entities {

    public class Usuario {
        
        [Key]
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}