using CQRS.Mediatr.Lite;

namespace Events.AggregateRoot
{
    public abstract class EntityBaseAggregateRoot<T> where T : class
    {
        public Guid Id { get; private set; }
        public T? Item { get; private set; }

        public DateTime? Creation { get; private set; }
        public IList<Event> UncommittedEvents { get; private set; } = new List<Event>();

        public EntityBaseAggregateRoot()
        {
            Id = Guid.NewGuid();
            Creation = DateTime.Now;
        }
    }
}
