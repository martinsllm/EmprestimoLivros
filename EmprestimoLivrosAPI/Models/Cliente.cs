using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivrosAPI.Models {

    public class Cliente {

        [Key]
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Email { get; set; }

        public required string Telefone { get; set; }

        public virtual ICollection<Emprestimo>? Emprestimo { get; set; }
    }
}