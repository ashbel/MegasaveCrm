using Megasave.Domain.Entities.Base;
using Megasave.Domain.Enums;

namespace Megasave.Domain.Entities
{
    public class Batches : BaseModel
    {
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Total { get; set; }
        public int? Count { get; set; }
        public Status? Status { get; set; }
        public string? UserId { get; set; }
        public Guid? BranchId { get; set; }
        public string? Notes { get; set; }
        public Guid? PayTypeId { get; set; }
        public string? DocumentNumber { get; set; }

        //public virtual Users User { get; set; }
        public virtual Branches Branch { get; set; }
        public virtual PayTypes PayType { get; set; }
    }
}