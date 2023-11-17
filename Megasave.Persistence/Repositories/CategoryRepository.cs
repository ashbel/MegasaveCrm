using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Categories>, ICategoryRepository
    {
        public CategoryRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}