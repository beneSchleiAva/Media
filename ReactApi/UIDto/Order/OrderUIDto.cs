using System.Text.Json.Serialization;
using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;
using Persistence.Entities.Concrete;

namespace ReactApi.UIDto.Order
{
    public class OrderUIDto : IOrder
    {
        public IEnumerable<OrderPositionUIDto> OrderPositions { get; set; } = new List<OrderPositionUIDto>();
        [JsonIgnore]
        public IEnumerable<IOrderPosition> Positions => OrderPositions;

        public decimal GetTotalPrice()
        {
            return OrderPositions.Sum(p=>p.OrderDescription.Quantity*p.OrderDescription.EffectivePrice);
        }

        public OrderUIDto() { }

        public OrderUIDto(IOrder interfaceOrder) {
            if (interfaceOrder?.Positions is not null)
                OrderPositions = interfaceOrder.Positions.Select(p => new OrderPositionUIDto(p));
            else OrderPositions = new List<OrderPositionUIDto>();
        }

        public OrderUIDto(OrderEntity entity)
        {
            if (entity?.Positions is not null)
                OrderPositions = entity.Positions.Select(p => new OrderPositionUIDto(p));
            else OrderPositions = new List<OrderPositionUIDto>();
        }
    }
}
