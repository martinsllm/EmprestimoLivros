using EmprestimoLivrosAPI.DTOs;
using EmprestimoLivrosAPI.Models;

namespace EmprestimoLivrosAPI.Repositories.Interfaces {

    public interface IUsuarioRepository {

        Task<Usuario> Create(Usuario usuario);

        Task<Usuario?> Login(LoginDTO login);
        
    }
}