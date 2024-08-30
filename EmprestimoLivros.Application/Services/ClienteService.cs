using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;

namespace EmprestimoLivros.Application.Services {

    public class ClienteService : IClienteService {

        private readonly IClienteRepository _clienteRepository;

        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clientRepository, IMapper mapper) {
            _clienteRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<List<ClienteDTO>> Get() {
            var clientes = await _clienteRepository.Get();
            return _mapper.Map<List<ClienteDTO>>(clientes);
        }

        public async Task<ClienteDTO> GetById(int id) {
            var cliente = await _clienteRepository.GetById(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task<Cliente> GetByEmail(string email) {
            var cliente = await _clienteRepository.GetByEmail(email);
            return cliente;
        }

        public async Task<Cliente> Create(ClienteDTO clienteDTO){
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            var clienteCriado = await _clienteRepository.Create(cliente);
            return clienteCriado;
        }

        public async Task<Cliente?> Update(ClienteDTO clienteDTO, int id) {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            var clienteAlterado = await _clienteRepository.Update(cliente, id);
            return clienteAlterado;
        }

        public async Task<Cliente?> Remove(int id) {
            var clienteExcluido = await _clienteRepository.Remove(id);
            return clienteExcluido;
        }

    }
}