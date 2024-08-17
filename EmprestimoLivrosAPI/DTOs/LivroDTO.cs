namespace EmprestimoLivrosAPI.DTOs {

    public class LivroDTO {
        
        public required string Nome { get; set; }

        public required string Autor { get; set; }

        public required string Editora { get; set; }

        public required string AnoPublicacao { get; set; }
    }
}