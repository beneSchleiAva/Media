using ModelInterface.Factories;
using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;
using ModelInterface.Interface.ValueObjects;

namespace Persistence.Entities.Concrete
{
    public class ProductEntityMapper : IProduct
    {

        public ProductEntity Entity { get; set; }

        public IProductId? ProductId => ProductIdFactory.Create(Entity.Id);

        public string? Name => Entity.Name;

        public string? Description => Entity.Description;

        public IProductPrice? Price { get { return ProductPriceFactory.Create(Entity?.BookUnitPrice ?? 0); } }

        public ProductEntityMapper()
        {
            Entity = new();
        }
        public ProductEntityMapper(IProduct position)
        {
            Entity = new ProductEntity();
            Entity.Id = position?.ProductId?.Value??Guid.Empty;
            Entity.Name= position?.Name??string.Empty;
            Entity.BookUnitPrice= position?.Price?.Value??0;
            Entity.Description= position?.Description??string.Empty;
        }
        public ProductEntityMapper(ProductEntity entity)
        {
            Entity = entity;
        }
    }
}
