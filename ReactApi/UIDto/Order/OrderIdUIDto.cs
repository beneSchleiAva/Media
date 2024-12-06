using ModelInterface.Interface.ValueObjects;

namespace ReactApi.UIDto.Order
{
    public class OrderIdUIDto : IOrderId
    {
        public Guid Value { get; set; }

        public OrderIdUIDto()
        {
            Value = Guid.Empty;
        }

        public OrderIdUIDto(Guid value)
        {
            Value = value;
        }
    }
}