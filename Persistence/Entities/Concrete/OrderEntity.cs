using System.ComponentModel.DataAnnotations;
using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;

namespace Persistence.Entities.Concrete
{
    public class OrderEntity
    {
        [Key]
        public Guid Id { get; set; }
       public List<OrderPositionEntity>? Positions { get; set; }

        public OrderEntity() { }
        public OrderEntity(IOrder interfaceOrder) {

            List<OrderPositionEntity> orderPositionEntities = new List<OrderPositionEntity>();
            foreach (IOrderPosition interfacePosition in interfaceOrder.Positions)
            {
                orderPositionEntities.Add(new OrderPositionEntity(interfacePosition));
            }

            Positions = orderPositionEntities;
        }

    }
}
