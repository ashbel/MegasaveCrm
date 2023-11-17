using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Megasave.Application.Contracts.Persistence;

namespace Megasave.Persistence.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly MopaneDbContext _dbContext;

        public BaseRepository(MopaneDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<List<T>> GetAll(Expression<Func<T, bool>> expression) => await _dbContext.Set<T>().AsNoTracking().Where(expression).ToListAsync();

        public virtual async Task<IReadOnlyList<T>> GetAllPaged(int page, int size)
        {
            return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}