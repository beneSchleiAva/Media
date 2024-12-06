using Microsoft.EntityFrameworkCore;
using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;
using Persistence.Entities.Concrete;
using Persistence.Entities.Concrete.Context;
using Persistence.Repositories.Abstract;

namespace Persistence.Repositories.Concrete
{
    public class PersistentQueryRepository<T> : IQueryRepository<T> where T : class
    {
        private readonly EntityContext context;
        public PersistentQueryRepository(EntityContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            if (typeof(T).IsAssignableTo(typeof(IProduct)) && context.Products is not null)
            {
                var entities = context.Products.ToList();
                return (IEnumerable<T>)entities.Select(e => new ProductEntityMapper(e)).ToList();

            }
            if (typeof(T).IsAssignableTo(typeof(IOrderPosition)) && context.OrderPositions is not null)
            {
                var entries = context.OrderPositions.ToList();
                return (IEnumerable<T>)entries.Select(e => new OrderPositionEntityMapper(e)).ToList(); 
            }
            if (typeof(T).IsAssignableTo(typeof(IOrder)) && context.Orders is not null)
            {
                var entries = context.Orders.Include(o=>o.Positions).ToList();
                return (IEnumerable<T>)entries.Select(e => new OrderEntityMapper(e)).ToList();
            }
            return new List<T>();
        }
    }
}
