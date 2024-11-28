using Events.Events.EntityCreated;

namespace Events.AggregateRoot
{
    public class CreateEntityAggregateRoot<T> : EntityBaseAggregateRoot<T> where T : class
    {
        public CreateEntityAggregateRoot() : base() { }
        public void Create(T item)
        {
            if (item is not null)
            {
                //4
                UncommittedEvents.Add(new EntityCreatedEvent<T>(this));
            }
        }
    }
}
