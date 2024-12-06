using FactoringDomain.Model.ValueObjects.Product;
using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;
using ModelInterface.Interface.ValueObjects;

namespace ModelInterface.Model
{
    internal class ConcreteOrderPosition : IOrderPosition
    {
        public Guid? Id { get; private set; }
        public IOrderDescription OrderDescription { get; private set; }
        public IProductId ProductId { get; private set; }
        public DateTime Created { get; private set; }

        public IProductPrice ProductBookUnitPrice { get; set; }

        public ConcreteOrderPosition(IProduct product, IOrderDescription orderDescription)
        {
            if (product.ProductId is not null)
                ProductId = product.ProductId;
            else
                ProductId = new ConcreteProductId();

            if (product.Price is not null)
                ProductBookUnitPrice = product.Price;
            else
                ProductBookUnitPrice = new ConcreteProductPrice(0);

            OrderDescription = orderDescription;
            Created = DateTime.Now;
        }
    }
}
