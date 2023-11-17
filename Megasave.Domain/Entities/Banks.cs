using Megasave.Domain.Entities.Base;

namespace Megasave.Domain.Entities
{
    public class Banks : BaseModel
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string BranchName { get; set; }
        public string Comment { get; set; }
    }
}