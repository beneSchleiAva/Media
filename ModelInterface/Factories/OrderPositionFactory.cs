using ModelInterface.Interface.Aggregates;
using ModelInterface.Model;

namespace ModelInterface.Factories
{
    public class OrderPositionFactory
    {
        public static IOrderPosition Create(Guid productId, string productName, decimal productPrice, decimal totalPrice, int quantity)
        {
            return new ConcreteOrderPosition(productId, productName, productPrice,totalPrice, quantity);
        }
    }
}
