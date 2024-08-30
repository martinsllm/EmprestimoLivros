using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Domain.Interfaces {

    public interface IUsuarioRepository {

        Task<Usuario> Create(Usuario usuario);

        Task<Usuario?> GetByEmail(string email);

        Task<string?> Login(string email, string password);

        string GenerateToken(int id, string email);
        
    }
}