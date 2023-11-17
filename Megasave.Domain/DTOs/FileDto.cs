namespace Megasave.Domain.DTOs
{
    public class FileDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid BatchId { get; set; }
        public BatchDto Batch { get; set; }
    }
}