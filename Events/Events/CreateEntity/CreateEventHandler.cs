using CQRS.Mediatr.Lite;
using Events.EventsStore;

namespace Events.Events.CreateEntity
{
    public class CreateEventHandler<T, U> : CQRS.Mediatr.Lite.EventHandler<T> where T : CreateEvent<U> where U : class
    {
        private readonly IEventsStore _eventStore;

        public CreateEventHandler(IEventsStore eventStore)
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
