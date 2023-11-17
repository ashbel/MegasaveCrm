using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class PayTypeRepository : BaseRepository<PayTypes>, IPayTypeRepository
    {
        public PayTypeRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}