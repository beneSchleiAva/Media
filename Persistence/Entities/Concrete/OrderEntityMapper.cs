using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;

namespace Persistence.Entities.Concrete
{
    public class OrderEntityMapper : IOrder
    {

        public OrderEntity Entity { get; set; }


        public IEnumerable<IOrderPosition> Positions { get {
                if (Entity.Positions is not null)
                    return Entity.Positions.Select(p => new OrderPositionEntityMapper(p));
                else return new List<IOrderPosition>();
            }
        }

        public OrderEntityMapper()
        {
            Entity = new();
        }
        public OrderEntityMapper(IOrder position)
        {
            Entity = new OrderEntity();
            Entity.Positions= position.Positions.Select(Positions => new OrderPositionEntityMapper(Positions).Entity).ToList();
        }
        public OrderEntityMapper(OrderEntity entity)
        {
            Entity = entity;
        }

        public decimal GetTotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
