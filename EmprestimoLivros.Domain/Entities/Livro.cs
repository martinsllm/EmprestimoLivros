using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.Domain.Entities {

    public class Livro {

        [Key]
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Autor { get; set; }

        public required string Editora { get; set; }

        public required string AnoPublicacao { get; set; }

        public virtual ICollection<Emprestimo>? Emprestimo { get; set; }
    }
}