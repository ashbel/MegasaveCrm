using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class PaymentRepository : BaseRepository<Payments>, IPaymentRepository
    {
        public PaymentRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}