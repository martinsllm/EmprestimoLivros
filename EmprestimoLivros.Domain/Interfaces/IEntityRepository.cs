namespace EmprestimoLivros.Domain.Interfaces {

    public interface IEntityRepository<T> {

        Task<List<T>> Get();

        Task<T?> GetById(int id);

        Task<T> Create(T data);

        Task<T?> Update(T data, int id);

        Task<T?> Remove(int id);

    }
}