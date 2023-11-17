using Megasave.Domain.Enums;

namespace Megasave.Domain.DTOs
{
    public class CreateBatchDto
    {
        public string Name { get; set; } = "New Purchase Order";
        public DateTime Date { get; set; } = DateTime.Now;
        public int Count { get; set; } = 0;
        public decimal Total { get; set; } = 0;
        public Status Status { get; set; } = Status.Draft;
        //public List<TransactionDto> TransactionList { get; set; }
        //public List<FileDto> FileList { get; set; }
        //public List<ApproversDto> ApproversList { get; set; }
        public string Notes { get; set; }
        public Guid UserId { get; set; }
        public Guid BranchId { get; set; } = new Guid("08db2960-fa02-4486-89dc-73b58107455d");
        public string DocumentNumber { get; set; } = new Random().Next(100000).ToString("000000");
    }
}