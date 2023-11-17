using Megasave.Domain.Entities.Base;
using Megasave.Domain.Enums;

namespace Megasave.Domain.DTOs
{
    public class BatchHistoryDto : BaseModel
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public Guid BatchesId { get; set; }
        public Actions Action { get; set; }
    }
}