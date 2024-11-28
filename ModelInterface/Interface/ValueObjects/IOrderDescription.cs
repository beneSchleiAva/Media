namespace ModelInterface.Interface.ValueObjects
{
    public interface IOrderDescription
    {
        int Quantity { get; }
        decimal TotalPrice { get; }
    }
}
