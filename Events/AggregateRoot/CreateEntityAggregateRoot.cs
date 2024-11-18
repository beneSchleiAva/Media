using Events.Events.CreateEntity;

namespace Events.AggregateRoot
{
    public class CreateEntityAggregateRoot<T> : EntityBaseAggregateRoot<T> where T : class
    {
        public CreateEntityAggregateRoot():base() { }
        public void Create(T item)
        {
            if (item is not null)
            {
                UncommittedEvents.Add(new CreateEvent<T>(this));
            }
        }
    }
}
