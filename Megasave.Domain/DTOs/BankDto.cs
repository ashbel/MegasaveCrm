namespace Megasave.Domain.DTOs
{
    public record BankDto
    (
        Guid Id,
        string Name,
        string Account,
        string BranchName,
        string Comment
    );
}