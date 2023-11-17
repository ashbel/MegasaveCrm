using Megasave.Domain.Entities.Base;

namespace Megasave.Domain.Entities
{
    public class CashRequests : BaseModel
    {
        public Guid tblBranchId { get; set; }
        public Guid User { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }

        public virtual Branches tblBranch { get; set; }

    }
}