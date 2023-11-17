using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class BatchHistoryRepository : BaseRepository<BatchesHistory>, IBatchHistoryRepository
    {
        public BatchHistoryRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}