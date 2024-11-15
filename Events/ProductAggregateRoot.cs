using CQRS.Mediatr.Lite;
using Events.Events;
using ModelInterface.Interface;

namespace Events
{
    public class ProductAggregateRoot
    {

        public string Id;


        public IProduct? Product { get; private set; }

        public DateTime? CreationDate { get; private set; }
        public DateTime? ShippedDate { get; private set; }
        public DateTime? DeliveryDate { get; private set; }

        public string? ShippingAddress { get; private set; }

        public IList<Event> UncommittedEvents { get; private set; } = new List<Event>();


        public ProductAggregateRoot()
        {
            Id = Guid.NewGuid().ToString();
        }

        public void CreateProduct(IProduct product)
        {
            if (product is not null)
            {
                this.Product = product;
                UncommittedEvents.Add(new ProductPurchasedEvent(this));
            }
        }

    }
}
