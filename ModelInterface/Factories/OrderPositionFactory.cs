using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;
using ModelInterface.Model;

namespace ModelInterface.Factories
{
    public class OrderPositionFactory
    {
        public static IOrderPosition Create(IProduct product, decimal totalPrice, int quantity)
        {
            return new ConcreteOrderPosition(product,totalPrice, quantity);
        }
    }
}
