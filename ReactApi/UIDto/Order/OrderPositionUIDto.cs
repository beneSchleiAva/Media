using System.Text.Json.Serialization;
using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.ValueObjects;
using Persistence.Entities.Concrete;
using ReactApi.UIDto.Product;

namespace ReactApi.UIDto.Order
{
    public class OrderPositionUIDto : IOrderPosition
    {
        public ProductIdUIDto ReferenceProduct { get; set; }
        public ProductPriceUIDto ReferenceBilledProductUnitPrice { get; set; }
        public ProductPriceUIDto ReferenceCurrentProductBookUnitPrice { get; set; }
        public OrderDescriptionUIDto ReferenceOrderDescription { get; set; }

        #region JsonIgnoreProperties
        [JsonIgnore]
        public IProductId ProductId => ReferenceProduct;

        [JsonIgnore]
        public IProductPrice BilledProductUnitPrice => ReferenceBilledProductUnitPrice;

        [JsonIgnore]
        public IProductPrice CurrentProductBookUnitPrice => ReferenceCurrentProductBookUnitPrice;

        [JsonIgnore]
        public IOrderDescription OrderDescription => ReferenceOrderDescription;
        #endregion

        public OrderPositionUIDto() { }
        internal OrderPositionUIDto(IOrderPosition orderPosition)
        {
            if (orderPosition?.ProductId?.Value is not null)
                ReferenceProduct = new(orderPosition.ProductId.Value);
            else ReferenceProduct = new();

            if (orderPosition?.OrderDescription?.Quantity is not null && orderPosition?.OrderDescription?.EffectivePrice is not null)
                ReferenceOrderDescription = new(orderPosition.OrderDescription.Quantity, orderPosition.OrderDescription.EffectivePrice);
            else ReferenceOrderDescription = new();

            if (orderPosition?.BilledProductUnitPrice?.Value is not null)
                ReferenceBilledProductUnitPrice = new(orderPosition.BilledProductUnitPrice.Value);
            else ReferenceBilledProductUnitPrice = new();

            if (orderPosition?.CurrentProductBookUnitPrice?.Value is not null)
                ReferenceCurrentProductBookUnitPrice = new(orderPosition.CurrentProductBookUnitPrice.Value);
            else ReferenceCurrentProductBookUnitPrice = new();
        }
        
        internal OrderPositionUIDto(OrderPositionEntity orderPosition)
        {
            if (orderPosition?.ProductId is not null)
                ReferenceProduct = new(orderPosition.ProductId);
            else ReferenceProduct = new();

            if (orderPosition?.Quantity is not null && orderPosition?.BilledUnitPrice is not null)
                ReferenceOrderDescription = new(orderPosition.Quantity, orderPosition.BilledUnitPrice);
            else ReferenceOrderDescription = new();


            if (orderPosition?.CurrentBookUnitPrice is not null)
                ReferenceCurrentProductBookUnitPrice = new(orderPosition.CurrentBookUnitPrice);
            else ReferenceCurrentProductBookUnitPrice = new();
        }
    }
}