using ModelInterface.Interface.Aggregates;

namespace ModelInterface.Model
{
    internal class ConcreteOrderPosition : IOrderPosition
    {
        public Guid ProductId { get; private set; }

        public int Quantity { get; private set; }

        public int Discount { get; private set; }

        public decimal TotalPrice { get; private set; }

        public ConcreteOrderPosition(Guid productId, decimal totalPrice, int discount,int quantity)
        {
            ProductId = productId;
            TotalPrice= totalPrice;
            Discount = discount;
            Quantity = quantity;
        }
    }
}
