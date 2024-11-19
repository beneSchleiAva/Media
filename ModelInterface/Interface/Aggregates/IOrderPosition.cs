namespace ModelInterface.Interface.Aggregates
{
    public interface IOrderPosition
    {
        Guid ProductId { get; }
        string ProductName { get; }
        decimal ProductPrice { get; }
        int Quantity { get; }
        decimal TotalPrice { get; }

        decimal CalculateGivenDiscount();
    }

}
