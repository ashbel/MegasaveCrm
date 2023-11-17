using Megasave.Application.Contracts.Persistence;
using Megasave.Domain.Entities;
using Megasave.Persistence.Repositories.Base;

namespace Megasave.Persistence.Repositories
{
    public class DepartmentRepository : BaseRepository<Departments>, IDepartmentRepository
    {
        public DepartmentRepository(MopaneDbContext dbContext) : base(dbContext)
        {
        }
    }
}