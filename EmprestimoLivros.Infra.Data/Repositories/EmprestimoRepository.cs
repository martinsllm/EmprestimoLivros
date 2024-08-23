using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.Infra.Data.Repositories {

    public class EmprestimoRepository : IEmprestimoRepository {

        private readonly EmprestimoDbContext _context;

        public EmprestimoRepository(EmprestimoDbContext context) {
            _context = context;
        }

        public async Task<List<Emprestimo>> GetByCliente(int id) {
            return await _context.Emprestimos
                .Where(x => x.ClienteId == id)
                .Include(livro => livro.Livro)
                .ToListAsync();
        }

        public async Task<Emprestimo?> GetById(int id) {
            return await _context.Emprestimos.FindAsync(id);
        }

        public async Task<Emprestimo> Create(Emprestimo emprestimoData) {
            await _context.Emprestimos.AddAsync(emprestimoData);
            await _context.SaveChangesAsync();
            return emprestimoData;
        }

        public async Task<Emprestimo?> Remove(int id) {
            var emprestimo = await GetById(id);

            if(emprestimo != null) {
                _context.Emprestimos.Remove(emprestimo);
                await _context.SaveChangesAsync();

                return emprestimo;
            }

            return null;
        }

    }
}