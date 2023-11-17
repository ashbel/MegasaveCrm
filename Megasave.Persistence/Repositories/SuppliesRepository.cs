using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class SuppliesRepository : BaseRepository<Supplies>, ISupplierRepository
    {
        public SuppliesRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}