using ModelInterface.Interface.ValueObjects;

namespace FactoringDomain.Model.ValueObjects.Product
{
    internal class ConcreteProductPrice : IProductPrice
    {
        public decimal Value { get; private set; }
        public ConcreteProductPrice(decimal price)
        {
            Value = price;
        }
    }
}
