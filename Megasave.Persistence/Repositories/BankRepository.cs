using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class BankRepository : BaseRepository<Banks>, IBankRepository
    {
        public BankRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}