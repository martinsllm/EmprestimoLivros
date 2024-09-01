using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Domain.Interfaces {

    public interface IEmprestimoRepository {

        Task<List<Emprestimo>> GetByCliente(int clienteId);

        Task<Emprestimo?> GetById(int id);

        Task<Emprestimo?> GetByLivro(int livroId);

        Task<Emprestimo?> Create(Emprestimo data);

        Task<Emprestimo?> ChangeStatus(int id);

    }
}