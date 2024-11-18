using ModelInterface.Interface.Elements;

namespace Persistence.Entities
{
    internal class ProductEntity : IProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0;

        public ProductEntity(IProduct product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
        }
    }
}
