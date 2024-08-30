using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EmprestimoLivros.Infra.Data.Repositories {

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

        public async Task<Usuario?> GetByEmail(string email) {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<string?> Login(string email, string password) {
            var user = await GetByEmail(email);

            if(user != null) {
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);
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