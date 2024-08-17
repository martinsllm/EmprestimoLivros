using EmprestimoLivrosAPI.Models;

namespace EmprestimoLivrosAPI.Repositories.Interfaces {

    public interface IEmprestimoRepository {

        Task<List<Emprestimo>> GetByCliente(int id);

        Task<Emprestimo?> GetById(int id);

        Task<Emprestimo> Create(Emprestimo data);

        Task<Emprestimo?> Remove(int id);

    }
}