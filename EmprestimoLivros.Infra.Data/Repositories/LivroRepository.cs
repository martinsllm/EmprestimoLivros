using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.Infra.Data.Repositories {

    public class LivroRepository : ILivroRepository {

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

        public async Task<Livro?> Update(Livro livroData, int id) {
            var livro = await GetById(id);

            if(livro != null) {
                livro.Nome = livroData.Nome;
                livro.Autor = livroData.Autor;
                livro.Editora = livroData.Editora;
                livro.AnoPublicacao = livroData.AnoPublicacao;

                _context.Livros.Update(livro);
                await _context.SaveChangesAsync();

                return livro;
            }

            return null;
        }

        public async Task<Livro?> Remove(int id) {
            var livro = await GetById(id);

            if(livro != null) {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
                
                return livro;
            }

            return null;
        }
    }
}