namespace Megasave.Domain.DTOs
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public Guid BatchId { get; set; }
        public string Description { get; set; }
        public Guid SupplierId { get; set; }
        public Guid CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }

    }
}