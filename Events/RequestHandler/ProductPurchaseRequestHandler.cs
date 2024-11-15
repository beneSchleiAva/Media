using CQRS.Mediatr.Lite;
using Events.Events;
using Events.EventsStore;

namespace Events.RequestHandler
{
    public class ProductPurchaseRequestHandler : CQRS.Mediatr.Lite.EventHandler<ProductPurchasedEvent>
    {
        private readonly IEventsStore _eventStore;

        public ProductPurchaseRequestHandler(IEventsStore eventStore)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        protected override Task<VoidResult> ProcessRequest(ProductPurchasedEvent request)
        {
            _eventStore.AddEvent(request);
            return Task.FromResult(new VoidResult());
        }
    }
}
