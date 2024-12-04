using ModelInterface.Interface.ValueObjects;

namespace ModelInterface.Interface.Aggregates
{
    public interface IOrderPosition
    {
        IProductId ProductId { get; }
        IProductPrice BilledProductUnitPrice { get; }
        IProductPrice CurrentProductBookUnitPrice { get; }
        IOrderDescription OrderDescription { get; }
    }
}