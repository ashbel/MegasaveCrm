using Megasave.Domain.Entities.Base;

namespace Megasave.Domain.Entities
{
    public class PayTypes : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}