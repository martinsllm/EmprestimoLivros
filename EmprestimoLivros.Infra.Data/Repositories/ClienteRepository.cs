using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.Infra.Data.Repositories {

    public class ClienteRepository : IClienteRepository {

        private readonly EmprestimoDbContext _context;

        public ClienteRepository(EmprestimoDbContext context) {
            _context = context;
        }


        public async Task<List<Cliente>> Get() {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetById(int id) {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente?> GetByEmail(string email) {
            return await _context.Clientes.Where(cli => cli.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<Cliente> Create(Cliente clienteData) {
            await _context.Clientes.AddAsync(clienteData);
            await _context.SaveChangesAsync();
            return clienteData;
        }

        public async Task<Cliente?> Update(Cliente clienteData, int id) {
            var cliente = await GetById(id);

            if(cliente != null) { 
                cliente.Nome = clienteData.Nome;
                cliente.Email = clienteData.Email;
                cliente.Telefone = clienteData.Telefone;

                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();

                return cliente;
            }

            return null;
        }

        public async Task<Cliente?> Remove(int id) {
            var cliente = await GetById(id);

            if(cliente != null) {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();

                return cliente;
            }

            return null;
        }
    }
}