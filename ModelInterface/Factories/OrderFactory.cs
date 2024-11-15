using ModelInterface.Interface;
using ModelInterface.Model;

namespace ModelInterface.Factories
{
    public class OrderFactory
    {
        public static IOrder CreateOrder(IEnumerable<IProduct> products)
        {
            return new Order(products);
        }
    }
}
