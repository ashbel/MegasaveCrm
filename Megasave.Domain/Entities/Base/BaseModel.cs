namespace Megasave.Domain.Entities.Base
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; } = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        public DateTime Updated { get; set; } = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        public string? CreatedBy { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}