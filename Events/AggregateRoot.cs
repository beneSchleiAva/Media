using CQRS.Mediatr.Lite;
using Events.Events;

namespace Events
{
    public class AggregateRoot<T> where T : class
    {
        public string Id;

        public T? Item { get; private set; }

        public DateTime? Creation { get; private set; }

        public IList<Event> UncommittedEvents { get; private set; } = new List<Event>();


        public AggregateRoot()
        {
            Id = Guid.NewGuid().ToString();
        }

        public void CreateProduct(string name, T item)
        {
            if (item is not null)
            {
                this.Item = item;
                UncommittedEvents.Add(new IssuedEvent<T>(name, this));
            }
        }
    }
}
