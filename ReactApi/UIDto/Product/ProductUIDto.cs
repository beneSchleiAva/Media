using ModelInterface.Interface.Elements;
using ModelInterface.Interface.ValueObjects;
using System.Text.Json.Serialization;

namespace ReactApi.UIDto.Product
{
    public class ProductUIDto : IProduct
    {

        public ProductIdUIDto? ProductIdUIDto { get; set; }

        public ProductPriceUIDto? ProductPriceUIDto { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        [JsonIgnore]
        public IProductId? ProductId => ProductIdUIDto;
        [JsonIgnore]
        public IProductPrice? Price => ProductPriceUIDto;

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
                ProductPriceUIDto = new(product.Price.Value);
            else
                ProductPriceUIDto = new();

            if (product?.Name is not null)
                Name = product.Name;
            else
                Name = string.Empty;

            if (product?.Description is not null)
                Description = product.Description;
            else
                Description = string.Empty;
        }

    }
}
