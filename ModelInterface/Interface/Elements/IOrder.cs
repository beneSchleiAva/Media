using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.ValueObjects;

namespace ModelInterface.Interface.Elements
{
    public interface IOrder
    {
        public IOrderId? Id { get; }
        public IEnumerable<IOrderPosition> Positions { get; }
        public decimal GetTotalPrice();
    }
}
