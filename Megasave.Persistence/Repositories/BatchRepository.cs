using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Megasave.Persistence.Repositories
{
    public class BatchRepository : BaseRepository<Batches>, IBatchRepository
    {

        public BatchRepository(MopaneDbContext dbContext) : base(dbContext)
        {

        }

        public override async Task<IReadOnlyList<Batches>> GetAll()
        {
            return await _dbContext.Set<Batches>()
            .Include(t => t.Branch)
            .ToListAsync();
        }
    }
}