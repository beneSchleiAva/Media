using ModelInterface.Interface;

namespace Persistence.Entities
{
    internal class Product : IProduct
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0;

        public int Quantity { get; set; } = 0;

        public Product(IProduct product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Quantity = product.Quantity;
        }
    }
}
