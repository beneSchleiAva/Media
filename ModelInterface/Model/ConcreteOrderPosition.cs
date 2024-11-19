using ModelInterface.Interface.Aggregates;

namespace ModelInterface.Model
{
    internal class ConcreteOrderPosition : IOrderPosition
    {
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }

        public decimal TotalPrice { get; private set; }
        public decimal ProductPrice { get; private set; }

        public Guid ProductId { get; private set; }

        public ConcreteOrderPosition(Guid productId, string productName, decimal productPrice, decimal totalPrice, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            TotalPrice = totalPrice;
            ProductPrice = productPrice;
            Quantity = quantity;

        }

        public decimal CalculateGivenDiscount()
        {
            return Math.Round(((TotalPrice - (ProductPrice * Quantity)) / (ProductPrice)), 2);
        }
    }
}
