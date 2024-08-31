using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Application.Interfaces {

    public interface IEmprestimoService {

        Task<List<EmprestimoDTO>> GetByCliente(int clienteId);

        Task<Emprestimo?> GetByLivro(int livroId);

        Task<Emprestimo> Create(EmprestimoPostDTO emprestimoDTO);

        Task<Emprestimo?> Remove(int id);
    }
}