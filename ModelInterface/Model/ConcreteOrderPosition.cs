using FactoringDomain.Model.ValueObjects.Product;
using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;
using ModelInterface.Interface.ValueObjects;

namespace ModelInterface.Model
{
    internal class ConcreteOrderPosition : IOrderPosition
    {
        public IOrderDescription OrderDescription { get; private set; }
        public IProductId ProductId { get; private set; }
        public IProductPrice ProductPrice { get; private set; }
        public DateTime Created { get; private set; }

        public ConcreteOrderPosition(IProduct product, IOrderDescription orderDescription)
        {
            if (product.ProductId is not null)
                ProductId = product.ProductId;
            else
                ProductId = new ConcreteProductId();

            if (product.Price is not null)
                ProductPrice = product.Price;
            else
                ProductPrice = new ConcreteProductPrice(0);

            OrderDescription = orderDescription;
            Created = DateTime.Now;
        }

        public decimal CalculateGivenDiscount()
        {
            if (ProductPrice.Value == 0)
                return decimal.MinValue;
            return Math.Round((OrderDescription.TotalPrice - ProductPrice.Value * OrderDescription.Quantity) / (ProductPrice.Value * OrderDescription.Quantity), 2);
        }
    }
}
