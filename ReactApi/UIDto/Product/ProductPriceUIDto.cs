using ModelInterface.Interface.ValueObjects;

namespace ReactApi.UIDto.Product
{
    public class ProductPriceUIDto : IProductPrice
    {
        public decimal Value { get; set; }

        public ProductPriceUIDto(decimal value)
        {
            Value = value;
        }
        public ProductPriceUIDto()
        {
            Value = 0;
        }

    }
}
