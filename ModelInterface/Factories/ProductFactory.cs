using ModelInterface.Interface;
using ModelInterface.Model;

namespace ModelInterface.Factories
{
    public class ProductFactory
    {
        public static IProduct CreateProduct(string name, string description, decimal price, int quantity)
        {
            return new Product(name, description, price,quantity);
        }
    }
}
