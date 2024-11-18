using CQRS.Mediatr.Lite;
using Events.AggregateRoot;
using ModelInterface.Interface;

namespace Events.Commands.CreateEntity
{
    public class EntityCreateCommandHandler<T> : CommandHandler<EntityCreateCommand<T>, IdCommandResult> where T : class
    {
        private readonly IRepository<T> repository;
        private readonly IEventBus _eventBus;

        public EntityCreateCommandHandler(IRepository<T> repository, IEventBus eventBus)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        protected override async Task<IdCommandResult> ProcessRequest(EntityCreateCommand<T> request)
        {
            CreateEntityAggregateRoot<T> aggregateRoot = new();
            if (request.Item is not null)
            {
               
                aggregateRoot.Create(request.Item);
                repository.AddOrUpdate(request.Item);
                await _eventBus.Send(aggregateRoot.UncommittedEvents);
            }

            return new IdCommandResult(aggregateRoot.Id.ToString());
        }

    }
}