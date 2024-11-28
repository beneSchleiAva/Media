using ModelInterface.Interface.ValueObjects;

namespace FactoringDomain.Model.ValueObjects.Product
{
    internal class ConcreteProductId : IProductId
    {
        public Guid Value { get; private set; }
        public ConcreteProductId()
        {
            Value = Guid.NewGuid();
        }
    }
}
