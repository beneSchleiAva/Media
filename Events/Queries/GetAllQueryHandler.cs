using CQRS.Mediatr.Lite;
using ModelInterface.Interface;

namespace Events.Queries
{
    public class GetAllQueryHandler<T> : QueryHandler<GetAllQuery<T>, IEnumerable<T>> where T : class
    {
        private readonly IRepository<T> repository;

        public GetAllQueryHandler(IRepository<T> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException();
        }

        protected override Task<IEnumerable<T>> ProcessRequest(GetAllQuery<T> request)
        {
            return Task.FromResult(repository.GetAll(order => true));
        }
    }
}
