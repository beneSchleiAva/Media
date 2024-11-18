using ModelInterface.Interface.Elements;
using ModelInterface.Model;

namespace ModelInterface.Factories
{
    public class ProductFactory
    {
        public static IProduct CreateProduct(string name, string description, decimal price)
        {
            return new ConcreteProduct(name, description, price);
        }
    }
}
