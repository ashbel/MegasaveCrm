using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class EmailRepository : BaseRepository<Emails>, IEmailRepository
    {
        public EmailRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}