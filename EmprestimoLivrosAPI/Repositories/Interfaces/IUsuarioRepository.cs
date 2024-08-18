using EmprestimoLivrosAPI.DTOs;
using EmprestimoLivrosAPI.Models;

namespace EmprestimoLivrosAPI.Repositories.Interfaces {

    public interface IUsuarioRepository {

        Task<Usuario> Create(Usuario usuario);

        Task<string?> Login(LoginDTO login);

        string GenerateToken(int id, string email);
        
    }
}