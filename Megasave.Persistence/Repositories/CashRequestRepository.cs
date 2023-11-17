using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class CashRequestRepository : BaseRepository<CashRequests>, ICashRequestRepository
    {
        public CashRequestRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}