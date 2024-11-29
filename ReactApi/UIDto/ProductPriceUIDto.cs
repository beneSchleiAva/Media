using ModelInterface.Interface.ValueObjects;

namespace ReactApi.UIDto
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
