namespace Megasave.Domain.DTOs
{
    public class CreateBankDto
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string BranchName { get; set; }
        public string Comment { get; set; }
    }
}