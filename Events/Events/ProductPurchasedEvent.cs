using CQRS.Mediatr.Lite;
using ModelInterface.Interface;

namespace Events.Events
{
    public class ProductPurchasedEvent : Event
    {
        public override string Id { get; set; }
        public override string DisplayName
        {
            get
            {
                if (Product is not null && Product.Name is not null)
                    return Product.Name;
                return string.Empty;
            }
        }
        public IProduct? Product { get; set; }
        public int Quantity { get; set; }


        public ProductPurchasedEvent(ProductAggregateRoot productAggregate)
        {
            Id = productAggregate.Id;
            Product = productAggregate?.Product;


        }

        public ProductPurchasedEvent(IProduct product, int quantity)
        {
            Id = Guid.NewGuid().ToString();
            Product = product;
            Quantity = quantity;
        }
    }
}
