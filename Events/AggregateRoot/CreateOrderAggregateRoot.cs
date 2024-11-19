using Events.Events.CreateEntity;
using ModelInterface.Interface.Aggregates;

namespace Events.AggregateRoot
{
    public class CreateOrderAggregateRoot<T> : EntityBaseAggregateRoot<T> where T : class
    {

        public List<IOrderPosition>? Positions;

        public CreateOrderAggregateRoot() : base() { }

        public void CreateOrder(List<IOrderPosition> positions)
        {
            if (positions is not null)
            {
                Positions = positions;
                bool isValid = true;

                UncommittedEvents.Add(new CreateEvent<T>(this));
            }
        }
    }
}
