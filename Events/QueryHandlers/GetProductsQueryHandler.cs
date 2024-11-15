using CQRS.Mediatr.Lite;
using Events.Queries;
using ModelInterface.Interface;

namespace Events.QueryHandlers
{
    public class GetProductsQueryHandler : QueryHandler<GetProductsQuery, IEnumerable<IProduct>>
    {
        private readonly IProductRepository repository;

        public GetProductsQueryHandler(IProductRepository repository)
        {
            this.repository = repository?? throw new ArgumentNullException(nameof(IProductRepository));
        }

        protected override Task<IEnumerable<IProduct>> ProcessRequest(GetProductsQuery request)
        {
            return Task.FromResult(repository.GetOrders(order => true));
        }
    }
}
