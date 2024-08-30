using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Application.Interfaces {

    public interface IUsuarioService {

        Task<Usuario> Create(UsuarioDTO usuarioDTO);

        Task<Usuario> GetByEmail(string email);

        Task<string?> Login(string email, string password);


    }
}