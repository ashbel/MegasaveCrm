using Megasave.Domain.Entities.Base;

namespace Megasave.Domain.Entities
{
    public class Files : BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid BatchId { get; set; }
        public Batches Batch { get; set; }

    }
}