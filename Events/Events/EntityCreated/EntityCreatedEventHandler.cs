using CQRS.Mediatr.Lite;
using Events.EventsStore;

namespace Events.Events.EntityCreated
{
    public class EntityCreatedEventHandler<T, U> : CQRS.Mediatr.Lite.EventHandler<T> where T : EntityCreatedEvent<U> where U : class
    {
        private readonly IEventsStore _eventStore;

        public EntityCreatedEventHandler(IEventsStore eventStore)
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
