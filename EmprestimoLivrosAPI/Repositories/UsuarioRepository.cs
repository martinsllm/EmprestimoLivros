using AutoMapper;
using EmprestimoLivrosAPI.Database;
using EmprestimoLivrosAPI.DTOs;
using EmprestimoLivrosAPI.Models;
using EmprestimoLivrosAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivrosAPI.Repositories {

    public class UsuarioRepository : IUsuarioRepository {

        private readonly EmprestimoDbContext _dbContext;

        public UsuarioRepository(EmprestimoDbContext dbContext) {
            _dbContext = dbContext;
        }


        public async Task<Usuario> Create(Usuario usuarioData) {
            await _dbContext.Usuarios.AddAsync(usuarioData);
            await _dbContext.SaveChangesAsync();
            return usuarioData;
        }

        public async Task<Usuario?> Login(LoginDTO login) {
            var user = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Email == login.Email);

            if(user != null) {
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);
                if(isValidPassword) return user;
            }
            
            return null;
        }
    }
}