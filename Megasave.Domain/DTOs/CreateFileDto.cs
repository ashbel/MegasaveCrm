using Microsoft.AspNetCore.Http;

namespace Megasave.Domain.DTOs
{
    public class CreateFileDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? DocumentName { get; set; }
        public IFormFile InputFile { get; set; }
        //public FileType FileType { get; set; }
        public Guid BatchId { get; set; }
    }
}
