using EmprestimoLivrosAPI.Database;
using EmprestimoLivrosAPI.Models;
using EmprestimoLivrosAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivrosAPI.Repositories {

    public class LivroRepository : IEntityRepository<Livro> {

        private readonly EmprestimoDbContext _context;

        public LivroRepository(EmprestimoDbContext context) {
            _context = context;
        }

        public async Task<List<Livro>> Get() {
            return await _context.Livros.ToListAsync();
        }

        public async Task<Livro?> GetById(int id) {
            return await _context.Livros.FindAsync(id);
        }

        public async Task<Livro> Create(Livro livroData) {
            await _context.Livros.AddAsync(livroData);
            await _context.SaveChangesAsync();
            return livroData;
        }

        public Task<Livro?> Remove(int id) {
            throw new NotImplementedException();
        }

        public Task<Livro?> Update(Livro data, int id) {
            throw new NotImplementedException();
        }
    }
}