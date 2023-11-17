using Megasave.Domain.Entities.Base;

namespace Megasave.Domain.Entities
{
    public class Targets : BaseModel
    {
        public Guid tblCategoryId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public virtual Categories tblCategory { get; set; }
    }
}