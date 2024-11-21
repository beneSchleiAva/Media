using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;

namespace ModelInterface.Model
{
    internal class ConcreteOrderPosition : IOrderPosition
    {
        public int Quantity { get; private set; }
        public decimal TotalPrice { get; private set; }

        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal ProductPrice { get; private set; }


        public ConcreteOrderPosition(IProduct product, decimal totalPrice, int quantity)
        {
            ProductId = product.Id;
            ProductName = product.Name;
            TotalPrice = totalPrice;
            ProductPrice = product.Price;
            Quantity = quantity;

        }

        public decimal CalculateGivenDiscount()
        {
            return Math.Round(((TotalPrice - (ProductPrice * Quantity)) / (ProductPrice*Quantity)), 2);
        }
    }
}
