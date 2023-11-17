using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class ActivityRepository : BaseRepository<Activities>, IActivityRepository
    {
        public ActivityRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}