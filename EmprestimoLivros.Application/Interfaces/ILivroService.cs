using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Application.Interfaces {

    public interface ILivroService {

        Task<List<LivroDTO>> Get();

        Task<LivroDTO> GetById(int id);

        Task<Livro> Create(LivroDTO livroDTO);

        Task<Livro?> Update(LivroDTO livroDTO, int id);

        Task<Livro?> Remove(int id);

    }
}