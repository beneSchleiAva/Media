using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities.Concrete
{
    public class OrderPositionEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal BilledUnitPrice { get; set; }
        public decimal CurrentBookUnitPrice { get; set; }
    }
}
