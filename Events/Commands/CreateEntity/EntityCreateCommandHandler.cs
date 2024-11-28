using CQRS.Mediatr.Lite;
using Events.AggregateRoot;
using Events.Events.EntityCreated;
using Events.EventsStore;
using ModelInterface.Factories;
using ModelInterface.Interface;
using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;
using Persistence.Repositories.Abstract;

namespace Events.Commands.CreateEntity
{
    public class EntityCreateCommandHandler<T> : CommandHandler<EntityCreateCommand<T>, IdCommandResult> where T : class
    {
        private readonly IRepository<T> repository;
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;

        public EntityCreateCommandHandler(IRepository<T> repository, IEventBus eventBus, ICommandBus commandBus)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _commandBus = commandBus;
        }

        protected override async Task<IdCommandResult> ProcessRequest(EntityCreateCommand<T> request)
        {
            CreateEntityAggregateRoot<T> aggregateRoot = new();
            if (request.Item is not null)
            {

                aggregateRoot.Create(request.Item);
                repository.AddOrUpdate(request.Item);

                if (typeof(T) == typeof(IOrder))
                {
                    var product = ProductFactory.Create("", "", 12m);
                    var op = OrderPositionFactory.Create(product, 43546m, 456);
                    var opl = new List<IOrderPosition>() { op };
                    var i = OrderFactory.Create(opl);
                    var ev = new EntityCreatedEvent<IOrder>(i);
                    await  _eventBus.Send(ev);
                   
                }
            }

            return new IdCommandResult(aggregateRoot.Id.ToString());
        }

    }
}