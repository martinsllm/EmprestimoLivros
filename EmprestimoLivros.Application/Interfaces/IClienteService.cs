using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Application.Interfaces {

    public interface IClienteService {

        Task<List<ClienteDTO>> Get();

        Task<ClienteDTO> GetById(int id);

        Task<Cliente> GetByEmail(string email);

        Task<Cliente> Create(ClienteDTO clienteDTO);

        Task<Cliente?> Update(ClienteDTO clienteDTO, int id);

        Task<Cliente?> Remove(int id);

    }
}