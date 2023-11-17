using System.Linq.Expressions;

namespace Megasave.Application.Contracts.Persistence
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task<IReadOnlyList<T>> GetAllPaged(int page, int size);
        Task<List<T>> GetAll(Expression<Func<T, bool>> expression);
    }
}