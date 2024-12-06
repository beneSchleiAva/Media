using ModelInterface.Interface.ValueObjects;

namespace ReactApi.UIDto.Order
{
    public class OrderDescriptionUIDto : IOrderDescription
    {
        public int Quantity { get; set; }

        public decimal EffectivePrice { get; set; }

        public OrderDescriptionUIDto()
        {
            Quantity = 0;
            EffectivePrice = 0;
        }
        public OrderDescriptionUIDto(int quantity, decimal effectivePrice)
        {
            Quantity = quantity;
            EffectivePrice = effectivePrice;
        }

    }
}