namespace EmprestimoLivrosAPI.DTOs {

    public class EmprestimoDTO {
        public int Id { get; set; }
        
        public LivroDTO? Livro { get; set; }

        public required DateTime DataEmprestimo { get; set; }

        public required DateTime DataDevolucao { get; set; }

        public required bool Entregue { get; set; }
    }
}