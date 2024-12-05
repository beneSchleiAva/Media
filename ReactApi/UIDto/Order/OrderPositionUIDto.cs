using System.Text.Json.Serialization;
using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.ValueObjects;
using Persistence.Entities.Concrete;
using ReactApi.UIDto.Product;

namespace ReactApi.UIDto.Order
{
    public class OrderPositionUIDto : IOrderPosition
    {
        public ProductIdUIDto ProductIdUIDto{ get; set; }
        public ProductPriceUIDto ProductBookUnitPriceDto { get; set; }
        public OrderDescriptionUIDto OrderDescriptionDto { get; set; }

        #region JsonIgnoreProperties
        [JsonIgnore]
        public IProductId ProductId => ProductIdUIDto;

        [JsonIgnore]
        public IProductPrice ProductBookUnitPrice => ProductBookUnitPriceDto;

        [JsonIgnore]
        public IOrderDescription OrderDescription => OrderDescriptionDto;

        #endregion

        public OrderPositionUIDto() { }
        internal OrderPositionUIDto(IOrderPosition orderPosition)
        {
            if (orderPosition?.ProductId?.Value is not null)
                ProductIdUIDto = new(orderPosition.ProductId.Value);
            else ProductIdUIDto = new();

            if (orderPosition?.OrderDescription?.Quantity is not null && orderPosition?.OrderDescription?.EffectivePrice is not null)
                OrderDescriptionDto= new(orderPosition.OrderDescription.Quantity, orderPosition.OrderDescription.EffectivePrice);
            else OrderDescriptionDto = new();

            if (orderPosition?.ProductBookUnitPrice?.Value is not null)
                ProductBookUnitPriceDto= new(orderPosition.ProductBookUnitPrice.Value);
            else ProductBookUnitPriceDto= new();

     }
        
        internal OrderPositionUIDto(OrderPositionEntity orderPosition)
        {
            if (orderPosition?.ProductId is not null)
                ProductIdUIDto = new(orderPosition.ProductId);
            else ProductIdUIDto = new();

            if (orderPosition?.Quantity is not null && orderPosition?.BilledUnitPrice is not null)
                OrderDescriptionDto = new(orderPosition.Quantity, orderPosition.BilledUnitPrice);
            else OrderDescriptionDto = new();


            if (orderPosition?.ProductBookUnitPrice is not null)
                ProductBookUnitPriceDto = new(orderPosition.BilledUnitPrice);
            else ProductBookUnitPriceDto = new();
        }
    }
}