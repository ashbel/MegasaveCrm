using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository<Transactions>, ITransactionRepository
    {
        public TransactionRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}