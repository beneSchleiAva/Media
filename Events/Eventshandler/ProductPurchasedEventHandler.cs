using CQRS.Mediatr.Lite;
using Events.Events;
using Events.EventsStore;
using Events.EventStore;

namespace Events.Eventshandler
{
    public class ProductPurchasedEventHandler : CQRS.Mediatr.Lite.EventHandler<ProductPurchasedEvent>
    {
        private readonly IEventsStore _eventStore;

        public ProductPurchasedEventHandler(IEventsStore eventStore)
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
