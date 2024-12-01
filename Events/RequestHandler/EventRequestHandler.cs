﻿
using CQRS.Mediatr.Lite;
using Events.Events.CreateEntity;
using Events.Events.EntityCreated;
using Events.EventsStore;

namespace Events.RequestHandler
{
    public class EventRequestHandler<T, U> : CQRS.Mediatr.Lite.EventHandler<T> where T : CreateEvent<U> where U : class
    {
        private readonly IEventsStore _eventStore;

        public EventRequestHandler(IEventsStore eventStore)
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
