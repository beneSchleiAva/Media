using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;

namespace ModelInterface.Model
{
    internal class ConcreteOrder : IOrder
    {
        public Guid Id { get; private set; }

        public string DisplayName { get; private set; }

        public IEnumerable<IOrderPosition> Positions { get; private set; }

        public ConcreteOrder(List<IOrderPosition> positions)
        {
            Id = Guid.NewGuid();
            DisplayName = Id.ToString();
            Positions = positions;
        }

        public decimal GetTotalPrice()
        {
            return Positions.Sum(p => p.TotalPrice);
        }
    }
}
