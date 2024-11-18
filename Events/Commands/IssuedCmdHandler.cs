using CQRS.Mediatr.Lite;
using ModelInterface.Interface;

namespace Events.Commands
{
    public class IssuedCmdHandler<T> : CommandHandler<IssuedCmd<T>, IdCommandResult> where T : class
    {
        private readonly IRepository<T> repository;
        private readonly IEventBus _eventBus;

        public IssuedCmdHandler(IRepository<T> repository, IEventBus eventBus)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        protected override async Task<IdCommandResult> ProcessRequest(IssuedCmd<T> request)
        {
            AggregateRoot<T> aggregateRoot = new();
            if (request.Item is not null)
            {

                aggregateRoot.CreateProduct("Name", request.Item);
                repository.AddOrUpdate(request.Item);
                await _eventBus.Send(aggregateRoot.UncommittedEvents);
            }

            return new IdCommandResult(aggregateRoot.Id);
        }

    }
}