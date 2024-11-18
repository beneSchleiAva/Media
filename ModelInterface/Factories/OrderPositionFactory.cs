using ModelInterface.Interface.Aggregates;
using ModelInterface.Model;

namespace ModelInterface.Factories
{
    public class OrderPositionFactory
    {
        public static IOrderPosition Create(Guid productId, decimal totalPrice, int quantity, int discount)
        {
            return new ConcreteOrderPosition(productId,totalPrice,discount, quantity);
        }
    }
}
