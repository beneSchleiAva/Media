using ModelInterface.Factories;
using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.ValueObjects;

namespace Persistence.Entities.Concrete
{
    public class OrderPositionEntityMapper : IOrderPosition
    {

        public OrderPositionEntity Entity { get; set; }

        public IProductId ProductId => ProductIdFactory.Create(Entity.ProductId);

        public IProductPrice ProductBookUnitPrice => ProductPriceFactory.Create(Entity.BilledUnitPrice);

        public IOrderDescription OrderDescription => OrderDescriptionFactory.Create(Entity.BilledUnitPrice, Entity.Quantity);

        public OrderPositionEntityMapper()
        {
            Entity = new();
        }
        public OrderPositionEntityMapper(IOrderPosition position)
        {
            Entity = new OrderPositionEntity();
            Entity.ProductId = position.ProductId?.Value ?? Guid.Empty;
            Entity.Quantity = position.OrderDescription.Quantity;
            Entity.BilledUnitPrice = position.OrderDescription.EffectivePrice;
            Entity.ProductBookUnitPrice = position.ProductBookUnitPrice.Value;
        }
        public OrderPositionEntityMapper(OrderPositionEntity entity)
        {
            Entity = entity;
        }
    }
}
