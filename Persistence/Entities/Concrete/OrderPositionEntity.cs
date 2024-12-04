using System.ComponentModel.DataAnnotations;
using ModelInterface.Interface.Aggregates;

namespace Persistence.Entities.Concrete
{
    public class OrderPositionEntity
    {
        [Key]
        public Guid? Id { get; set; }
        public Guid ProductId { get; set ;}
        public int Quantity { get; set; }
        public decimal BilledUnitPrice { get; set; }
        public decimal CurrentBookUnitPrice { get; set; }

        public OrderPositionEntity() { } 
        public OrderPositionEntity(IOrderPosition interfacePosition) {
            ProductId = interfacePosition.ProductId.Value;
            Quantity = interfacePosition.OrderDescription.Quantity;
            BilledUnitPrice = interfacePosition.OrderDescription.EffectivePrice;
            CurrentBookUnitPrice = interfacePosition.CurrentProductBookUnitPrice.Value;
        } 
        
    }
}
