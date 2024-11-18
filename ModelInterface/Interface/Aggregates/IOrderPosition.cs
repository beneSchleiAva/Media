namespace ModelInterface.Interface.Aggregates
{
    public interface IOrderPosition
    {
        Guid ProductId { get; }
        int Quantity { get; }

        int Discount { get; }

        decimal TotalPrice { get;}
    }

}
