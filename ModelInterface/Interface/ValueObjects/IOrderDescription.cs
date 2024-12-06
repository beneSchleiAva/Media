namespace ModelInterface.Interface.ValueObjects
{
    public interface IOrderDescription
    {
        int Quantity { get; }
        decimal EffectivePrice { get; }
    }
}
