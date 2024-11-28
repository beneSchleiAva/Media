using ModelInterface.Interface.Elements;
using ModelInterface.Interface.ValueObjects;
using Persistence.Entities.Abstract;

namespace Persistence.Entities.Concrete
{
    internal class ProductEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public decimal Price { get; set; }

        public ProductEntity(IProduct product)
        {
            Id = product.Id?.Value ?? Guid.Empty;
            Name = product?.Name??"";
            Description = product?.Description??"";
            Price = product?.Price?.Value??0;
        }
    }
}
