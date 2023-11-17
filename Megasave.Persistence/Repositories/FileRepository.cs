using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class FileRepository : BaseRepository<Files>, IFileRepository
    {
        public FileRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}