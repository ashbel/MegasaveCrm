using Megasave.Domain.Entities.Base;

namespace Megasave.Domain.Entities
{
    public class Activities : BaseModel
    {
        public string Activity { get; set; }
        public Guid User { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Comment { get; set; }

    }
}