using Megasave.Domain.Entities.Base;

namespace Megasave.Domain.Entities
{
    public class Emails : BaseModel
    {
        public string EmailSmtp { get; set; }
        public string EmailAddress { get; set; }
        public string EmailPort { get; set; }
        public string emailUsername { get; set; }
        public string emailPassword { get; set; }
        public bool? emailSsl { get; set; }

    }
}