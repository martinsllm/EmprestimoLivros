namespace EmprestimoLivrosAPI.DTOs {

    public class EmprestimoPostDTO {

        public required int ClienteId { get; set; }

        public required int LivroId { get; set; }

        public required DateTime DataEmprestimo { get; set; }

        public required DateTime DataDevolucao { get; set; }

        public required bool Entregue { get; set; }
    }
}