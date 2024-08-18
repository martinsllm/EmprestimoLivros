using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EmprestimoLivrosAPI.Database;
using EmprestimoLivrosAPI.DTOs;
using EmprestimoLivrosAPI.Models;
using EmprestimoLivrosAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<string?> Login(LoginDTO login) {
            var user = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Email == login.Email);

            if(user != null) {
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);
                if(isValidPassword) return GenerateToken(user.Id, user.Email);
            }
            
            return null;
        }

        public string GenerateToken(int id, string email) {
            var claims = new[] {
                new Claim("id", id.ToString()),
                new Claim("email", email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Secret));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expirations = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                expires: expirations,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}