using Megasave.Domain.Entities.Base;

namespace Megasave.Domain.Entities
{
    public class Payments : BaseModel
    {
        public Guid User { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public Guid tblBatchId { get; set; }

        public virtual Batches tblBatch { get; set; }
    }
}