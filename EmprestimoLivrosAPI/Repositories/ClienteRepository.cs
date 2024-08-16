using EmprestimoLivrosAPI.Database;
using EmprestimoLivrosAPI.Models;
using EmprestimoLivrosAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivrosAPI.Repositories {

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

        public async Task<Cliente> Create(Cliente cliente) {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente?> Update(Cliente cliente, int id) {
            var foundClient = await GetById(id);

            if(foundClient != null) { 
                foundClient.Nome = cliente.Nome;
                foundClient.Email = cliente.Email;
                foundClient.Telefone = cliente.Telefone;

                _context.Clientes.Update(foundClient);
                await _context.SaveChangesAsync();

                return cliente;
            }

            return null;
        }

        public async Task<Cliente?> Remove(int id) {
            var foundClient = await GetById(id);

            if(foundClient != null) {
                _context.Clientes.Remove(foundClient);
                await _context.SaveChangesAsync();

                return foundClient;
            }

            return null;
        }
    }
}