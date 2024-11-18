using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;

namespace Persistence.Entities
{
    internal class OrderPositionEntity
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
