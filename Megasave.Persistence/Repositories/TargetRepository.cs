using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class TargetRepository : BaseRepository<Targets>, ITargetRepository
    {
        public TargetRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}