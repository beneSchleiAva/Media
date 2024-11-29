using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelInterface.Factories;
using ModelInterface.Interface.Elements;
using ModelInterface.Interface.ValueObjects;

namespace Persistence.Entities.Concrete
{
    public class ProductEntity : IProduct
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BookUnitPrice { get; set; }


        [NotMapped]
        public IProductPrice? Price { get => ProductPriceFactory.Create(BookUnitPrice); }

        [NotMapped]
        public IProductId? ProductId { get => ProductIdFactory.Create(Id); }

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
