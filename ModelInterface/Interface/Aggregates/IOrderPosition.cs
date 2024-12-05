using ModelInterface.Interface.ValueObjects;

namespace ModelInterface.Interface.Aggregates
{
    public interface IOrderPosition
    {
        IProductId ProductId { get; }
        IProductPrice ProductBookUnitPrice { get; }
        IOrderDescription OrderDescription { get; }
    }
}