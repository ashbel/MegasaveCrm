using Megasave.Domain.Entities.Base;

namespace Megasave.Domain.Entities
{
    public class Supplies : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        public string Comment { get; set; }
    }
}