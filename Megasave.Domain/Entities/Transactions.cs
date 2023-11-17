using Megasave.Domain.Entities.Base;

namespace Megasave.Domain.Entities
{
    public class Transactions : BaseModel
    {
        public Guid? SupplierId { get; set; }
        public decimal? Amount { get; set; } = 0;
        public Guid? BranchId { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Description { get; set; } = string.Empty;
        public decimal? Balance { get; set; } = 0;
        public Guid? User { get; set; }
        public DateTime? tranDate { get; set; } = DateTime.Now;
        public string? Status { get; set; }
        public Guid BatchId { get; set; }
        public int? Quantity { get; set; } = 0;

        public virtual Batches Batch { get; set; }
        public virtual Branches Branch { get; set; }
        public virtual Categories Category { get; set; }
        public virtual Supplies Supplier { get; set; }
    }
}