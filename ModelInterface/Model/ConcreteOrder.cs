using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;
using ModelInterface.Interface.ValueObjects;
using ModelInterface.Model.ValueObjects;

namespace ModelInterface.Model
{
    internal class ConcreteOrder : IOrder
    {
        public IOrderId? Id { get; private set; }

        public string DisplayName { get; private set; }

        public IEnumerable<IOrderPosition> Positions { get; private set; }

        public ConcreteOrder(IEnumerable<IOrderPosition> positions)
        {
            Id = new ConcreteOrderId();
            DisplayName = Id.Value.ToString();
            Positions = positions;
        }

        public decimal GetTotalPrice()
        {
            return Positions.Sum(p => p.OrderDescription.TotalPrice);
        }
    }
}
