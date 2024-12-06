using FactoringDomain.Model.ValueObjects.Product;
using ModelInterface.Interface.ValueObjects;

namespace ModelInterface.Factories
{
    public class ProductPriceFactory
    {
        public static IProductPrice Create(decimal price)
        {
            return new ConcreteProductPrice(price);
        }
    }
}
