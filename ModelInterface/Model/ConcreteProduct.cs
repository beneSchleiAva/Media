using FactoringDomain.Model.ValueObjects;
using FactoringDomain.Model.ValueObjects.Product;
using ModelInterface.Interface.Elements;
using ModelInterface.Interface.ValueObjects;

namespace ModelInterface.Model
{
    internal class ConcreteProduct : IProduct
    {
        public IProductId ProductId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IProductPrice Price { get; private set; }
        public int Quantity { get; private set; }

        public ConcreteProduct(string name, string description, decimal price)
        {
            ProductId = new ConcreteProductId();
            Name = name;
            Description = description;
            Price = new ConcreteProductPrice(price);
        }
    }
}
