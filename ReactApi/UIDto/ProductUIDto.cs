using ModelInterface.Interface.Elements;
using ModelInterface.Interface.ValueObjects;
using System.Text.Json.Serialization;

namespace ReactApi.UIDto
{
    public class ProductUIDto : IProduct
    {

        public ProductIdUIDto? ProductIdUIDto { get; set; }

        public ProductPriceUIDto? ProductPriceUIDto { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        [JsonIgnore]
        public IProductId? ProductId { get => ProductIdUIDto; set => ProductId = value; }
        [JsonIgnore]
        public IProductPrice? Price { get => ProductPriceUIDto; set => Price = value; }

        public ProductUIDto()
        {
            ProductIdUIDto = new();
            ProductPriceUIDto = new();
        }

        public ProductUIDto(IProduct product)
        {
            if (product?.ProductId?.Value is not null)
                ProductIdUIDto = new(product.ProductId.Value);
            else
                ProductIdUIDto = new();
            if (product?.Price?.Value is not null)
                ProductPriceUIDto = new (product.Price.Value);
            else
                ProductPriceUIDto = new();
            Name = product.Name;
            Description = product.Description;
        }

    }
}
