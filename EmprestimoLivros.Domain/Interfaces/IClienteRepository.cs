using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Domain.Interfaces {

    public interface IClienteRepository {

        Task<List<Cliente>> Get();

        Task<Cliente?> GetById(int id);

        Task<Cliente?> GetByEmail(string email);

        Task<Cliente> Create(Cliente cliente);

        Task<Cliente?> Update(Cliente cliente, int id);

        Task<Cliente?> Remove(int id);

    }
}