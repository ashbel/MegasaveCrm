using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class BranchRepository : BaseRepository<Branches>, IBranchRepository
    {
        public BranchRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}