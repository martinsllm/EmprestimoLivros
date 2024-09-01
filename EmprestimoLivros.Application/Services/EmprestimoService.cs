using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;

namespace EmprestimoLivros.Application.Services {

    public class EmprestimoService : IEmprestimoService {

        private readonly IEmprestimoRepository _emprestimoRepository;

        private readonly IMapper _mapper;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository, IMapper mapper) {
            _emprestimoRepository = emprestimoRepository;
            _mapper = mapper;
        }

        public async Task<List<EmprestimoDTO>> GetByCliente(int id) {
            var emprestimos = await _emprestimoRepository.GetByCliente(id);
            return _mapper.Map<List<EmprestimoDTO>>(emprestimos);
        }

        public async Task<Emprestimo?> GetByLivro(int livroId) {
            var emprestimo = await _emprestimoRepository.GetByLivro(livroId);
            return emprestimo;
        }

        public async Task<Emprestimo> Create(EmprestimoPostDTO emprestimoDTO) {
            var emprestimo = _mapper.Map<Emprestimo>(emprestimoDTO);
            var emprestimoCriado = await _emprestimoRepository.Create(emprestimo);
            return emprestimoCriado;
        }

        public async Task<Emprestimo?> Remove(int id) {
            var emprestimoDevolvido = await _emprestimoRepository.ChangeStatus(id);
            return emprestimoDevolvido;
        }
    }
}