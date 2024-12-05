using System.ComponentModel.DataAnnotations;
using ModelInterface.Interface.Elements;

namespace Persistence.Entities.Concrete
{
    public class ProductEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal BookUnitPrice { get; set; }

        public ProductEntity() { }
        public ProductEntity(IProduct product)
        {
            Id = product.ProductId?.Value ?? Guid.Empty;
            Name = product?.Name ?? "";
            Description = product?.Description ?? "";
            BookUnitPrice = product?.Price?.Value ?? 0;
        }
    }
}
