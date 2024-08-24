using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;

namespace EmprestimoLivros.Application.Services {

    public class LivroService : ILivroService {

        private readonly IEntityRepository<Livro> _livroRepository;

        private readonly IMapper _mapper;

        public LivroService(IEntityRepository<Livro> livroRepository, IMapper mapper) {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        public async Task<List<LivroDTO>> Get() {
            var livros = await _livroRepository.Get();
            return _mapper.Map<List<LivroDTO>>(livros);
        }

        public async Task<LivroDTO> GetById(int id) {
            var livro = await _livroRepository.GetById(id);
            return _mapper.Map<LivroDTO>(livro);
        }

        public async Task<Livro> Create(LivroDTO livroDTO) {
            var livro = _mapper.Map<Livro>(livroDTO);
            var livroCriado = await _livroRepository.Create(livro);
            return livroCriado;
        }

        public async Task<Livro?> Update(LivroDTO livroDTO, int id){
            var livro = _mapper.Map<Livro>(livroDTO);
            var livroAlterado = await _livroRepository.Update(livro, id);
            return livroAlterado;
        }

        public async Task<Livro?> Remove(int id) {
            var livroExcluido = await _livroRepository.Remove(id);
            return livroExcluido;
        }

    }

}