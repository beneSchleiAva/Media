using ModelInterface.Interface.Aggregates;

namespace ModelInterface.Interface.Elements
{
    public interface IOrder : IDomainElelement
    {
        public IEnumerable<IOrderPosition> Positions { get; }
        public decimal GetTotalPrice();
    }
}
