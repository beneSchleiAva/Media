using FactoringDomain.Model.ValueObjects.Product;
using ModelInterface.Interface.ValueObjects;

namespace ModelInterface.Factories
{
    public class ProductIdFactory
    {
        public static IProductId Create(Guid Id)
        {
            return new ConcreteProductId(Id);
        }
    }
}
