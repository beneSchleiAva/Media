using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities.Concrete
{
    public class OrderEntity
    {
        [Key]
        public Guid Id { get; set; }
       public List<OrderPositionEntity>? Positions { get; set; }
    }
}
