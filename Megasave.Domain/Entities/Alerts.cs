using Megasave.Domain.Entities.Base;

namespace Megasave.Domain.Entities
{
    public class Alerts : BaseModel
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool isRead { get; set; }
        public string Title { get; set; }
        public string AlertType { get; set; }

        //public virtual tblUser tblUser { get; set; }
        //public virtual tblUser tblUser1 { get; set; }
    }
}