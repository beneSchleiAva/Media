using CQRS.Mediatr.Lite;
using Events.AggregateRoot;

namespace Events.Events.EntityCreated
{
    public class EntityCreatedEvent<T> : Event where T : class
    {
        public override string Id { get; set; }
        public override string DisplayName { get; }
        public T? Item { get; set; }



        public EntityCreatedEvent(T item)
        {
            Id = Guid.NewGuid().ToString();
            DisplayName = nameof(EntityCreatedEvent<T>);
            Item = item;
        }

        public EntityCreatedEvent(EntityBaseAggregateRoot<T> aggregate)
        {
            Id = Guid.NewGuid().ToString();
            DisplayName = nameof(EntityCreatedEvent<T>);
            if (aggregate?.Item is not null)
                Item = aggregate.Item;

        }
    }
}
