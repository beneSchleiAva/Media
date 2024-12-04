using ModelInterface.Interface.ValueObjects;
using ModelInterface.Model.Entity;

namespace ModelInterface.Factories
{
    public class OrderDescriptionFactory
    {
        public static IOrderDescription Create(decimal totalPrice, int quantity)
        {
            return new ConcreteOrderDescription(quantity, totalPrice);
        }
    }
}
