using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivrosAPI.Models {

    public class Emprestimo {

        [Key]
        public int Id { get; set; }

        public required int ClienteId { get; set; }

        public required int LivroId { get; set; }

        public Cliente? Cliente { get; set; }

        public Livro? Livro { get; set; }

        public required DateTime DataEmprestimo { get; set; }

        public required DateTime DataDevolucao { get; set; }

        public required bool Entregue { get; set; }
    }
}