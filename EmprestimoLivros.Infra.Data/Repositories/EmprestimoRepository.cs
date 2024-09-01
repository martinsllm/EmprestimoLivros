using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.Infra.Data.Repositories {

    public class EmprestimoRepository : IEmprestimoRepository {

        private readonly EmprestimoDbContext _context;

        private readonly ILivroRepository _livroRepository;

        private readonly IClienteRepository _clienteRepository;

        public EmprestimoRepository(EmprestimoDbContext context, ILivroRepository livroRepository, IClienteRepository clienteRepository) {
            _context = context;
            _livroRepository = livroRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Emprestimo>> GetByCliente(int id) {
            return await _context.Emprestimos
                .Where(emp => emp.ClienteId == id && emp.Entregue == false)
                .Include(livro => livro.Livro)
                .ToListAsync();
        }

        public async Task<Emprestimo?> GetById(int id) {
            return await _context.Emprestimos
                .Where(emp => emp.Id == id && emp.Entregue == false)
                .FirstOrDefaultAsync();
        }

        public async Task<Emprestimo?> GetByLivro(int livroId) {
            return await _context.Emprestimos
                .FirstOrDefaultAsync(emp => emp.LivroId == livroId && emp.Entregue == false);
        }

        public async Task<Emprestimo?> Create(Emprestimo emprestimoData) {
            var cliente = await _clienteRepository.GetById(emprestimoData.ClienteId);
            var livro = await _livroRepository.GetById(emprestimoData.LivroId);

            if(livro == null || cliente == null) return null;

            await _context.Emprestimos.AddAsync(emprestimoData);
            await _context.SaveChangesAsync();
            return emprestimoData;
        }

        public async Task<Emprestimo?> ChangeStatus(int id) {
            var emprestimo = await GetById(id);

            if(emprestimo != null) {
                emprestimo.Entregue = true;
                _context.Emprestimos.Update(emprestimo);
                await _context.SaveChangesAsync();

                return emprestimo;
            }

            return null;
        }
    }
}