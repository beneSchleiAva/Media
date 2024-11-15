using CQRS.Mediatr.Lite;
using ModelInterface.Interface;

namespace Events.Commands
{
    public class PurchaseProductCmdHandler : CommandHandler<PurchaseProductCmd, IdCommandResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventBus _eventBus;

        public PurchaseProductCmdHandler(IProductRepository productRepository, IEventBus eventBus)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        protected override async Task<IdCommandResult> ProcessRequest(PurchaseProductCmd request)
        {
            ProductAggregateRoot productAggregate = new();
            if (request.Product is not null)
            {
                ProductAggregateRoot productAggregateRoot = new();
                productAggregateRoot.CreateProduct(request.Product);
                _productRepository.AddOrUpdate(request.Product);
                await _eventBus.Send(productAggregateRoot.UncommittedEvents);
            }

            return new IdCommandResult(new ProductAggregateRoot().Id);
        }
    }
}