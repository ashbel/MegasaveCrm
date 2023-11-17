using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class AlertRepository : BaseRepository<Alerts>, IAlertRepository
    {
        public AlertRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}