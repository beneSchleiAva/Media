using CQRS.Mediatr.Lite;

namespace Events.EventsStore
{
    public interface IEventsStore
    {
        void AddEvent(Event @event);
        IEnumerable<Event> Get();
    }
}
