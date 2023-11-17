using Megasave.Domain.Entities.Base;
using Megasave.Domain.Enums;

namespace Megasave.Domain.Entities
{
    public class BatchesHistory : BaseModel
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public Guid BatchesId { get; set; }
        public Actions Action { get; set; }
        //public virtual Users User { get; set; }
        public virtual Batches Batches { get; set; }
    }
}