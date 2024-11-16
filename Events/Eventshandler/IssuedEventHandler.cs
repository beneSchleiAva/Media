using CQRS.Mediatr.Lite;
using Events.Events;
using Events.EventsStore;

namespace Events.Eventshandler
{
    public class IssuedEventHandler<T, U> : CQRS.Mediatr.Lite.EventHandler<T> where T : IssuedEvent<U> where U : class
    {
        private readonly IEventsStore _eventStore;

        public IssuedEventHandler(IEventsStore eventStore)
        {
            _eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }


        protected override Task<VoidResult> ProcessRequest(T request)
        {
            _eventStore.AddEvent(request);
            return Task.FromResult(new VoidResult());
        }
    }
}
