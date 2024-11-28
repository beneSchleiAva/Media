using ModelInterface.Interface.ValueObjects;

namespace ModelInterface.Model.Entity
{
    internal class ConcreteOrderDescription : IOrderDescription
    {
        public int Quantity { get; private set; }
        public decimal TotalPrice { get; private set; }

        public ConcreteOrderDescription(int quantity, decimal totalPrice)
        {
            Quantity = quantity;
            TotalPrice = totalPrice;
        }
    }
}
