using CQRS.Mediatr.Lite;
using Events.EventsStore;

namespace Events.EventStore
{
    public class InMemEventStore : IEventsStore
    {
        private static IList<Event> _events = new List<Event>();
        public void AddEvent(Event @event)
        {
            _events.Add(@event);
        }

        public IEnumerable<Event> Get()
        {
            return _events;
        }
    }
}
