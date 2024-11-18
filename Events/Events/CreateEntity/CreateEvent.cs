using CQRS.Mediatr.Lite;
using Events.AggregateRoot;

namespace Events.Events.CreateEntity
{
    public class CreateEvent<T> : Event where T : class
    {
        public override string Id { get; set; }
        public override string DisplayName { get; }
        public T? Item { get; set; }


        public CreateEvent(EntityBaseAggregateRoot<T> aggregate)
        {
            Id = Guid.NewGuid().ToString();
            DisplayName = nameof(CreateEvent<T>);
            Item = aggregate?.Item;


        }

        public CreateEvent(T item)
        {
            Id = Guid.NewGuid().ToString();
            DisplayName = nameof(CreateEvent<T>);
            Item = item;
        }
    }
}
