using Megasave.Domain.Entities.Base;
using Megasave.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Megasave.Domain.DTOs
{
    public class BatchDto : BaseModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public int Count { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal Total { get; set; }
        public Status Status { get; set; }
        public List<TransactionDto> TransactionList { get; set; }
        public List<FileDto> FileList { get; set; }

        public List<ApproversDto> ApproversList { get; set; }
        public string Notes { get; set; }
        public string Prepared { get; set; }
        public string? DocumentNumber { get; set; }
        public Guid BranchId { get; set; }
        public BranchDto Branch { get; set; }
        public Guid UserId { get; set; }
        public string User { get; set; }
        public bool hasStatusChanged { get; set; } = false;
        public List<BatchHistoryDto> BatchesHistory { get; set; }
    }
}