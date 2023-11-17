using Megasave.Domain.Entities.Base;

namespace Megasave.Domain.DTOs
{
    public class BranchDto : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
