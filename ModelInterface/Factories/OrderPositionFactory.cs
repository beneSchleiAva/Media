using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;
using ModelInterface.Model;
using ModelInterface.Model.Entity;

namespace ModelInterface.Factories
{
    public class OrderPositionFactory
    {
        public static IOrderPosition Create(IProduct product, decimal totalPrice, int quantity)
        {
            var description = new ConcreteOrderDescription(quantity, totalPrice);
            return new ConcreteOrderPosition(product, description);
        }
    }
}
