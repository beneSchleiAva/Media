using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;
using ModelInterface.Model;

namespace ModelInterface.Factories
{
    public class OrderFactory
    {
        public static IOrder Create(IEnumerable<IOrderPosition> positions)
        {
            return new ConcreteOrder(positions);
        }
    }
}
