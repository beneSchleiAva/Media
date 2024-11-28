using ModelInterface.Interface.ValueObjects;

namespace ModelInterface.Interface.Aggregates
{
    public interface IOrderPosition
    {
        IProductId ProductId { get; }
        IProductPrice ProductPrice { get; }
        IOrderDescription OrderDescription { get; }

        decimal CalculateGivenDiscount();
    }

}
