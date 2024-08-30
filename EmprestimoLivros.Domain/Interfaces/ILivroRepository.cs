using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Domain.Interfaces {

    public interface ILivroRepository {

        Task<List<Livro>> Get();

        Task<Livro?> GetById(int id);

        Task<Livro> Create(Livro livro);

        Task<Livro?> Update(Livro livro, int id);

        Task<Livro?> Remove(int id);

    }
}