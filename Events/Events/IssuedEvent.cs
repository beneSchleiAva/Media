using CQRS.Mediatr.Lite;

namespace Events.Events
{
    public class IssuedEvent<T> : Event where T : class
    {
        public override string Id { get; set; }
        public override string DisplayName { get; }
        public T? Item { get; set; }


        public IssuedEvent(string displayName, AggregateRoot<T> aggregate)
        {
            Id = aggregate.Id;
            DisplayName = displayName;
            Item = aggregate?.Item;


        }

        public IssuedEvent(string displayName, T item)
        {
            Id = Guid.NewGuid().ToString();
            DisplayName = displayName;
            Item = item;
        }
    }
}
