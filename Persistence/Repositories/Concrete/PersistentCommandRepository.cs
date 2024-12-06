using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;
using Persistence.Entities.Concrete;
using Persistence.Entities.Concrete.Context;
using Persistence.Repositories.Abstract;

namespace Persistence.Repositories.Concrete
{
    public class PersistentCommandRepository<T> : ICommandRepository<T> where T : class
    {
        private readonly EntityContext context;
        public PersistentCommandRepository(EntityContext context)
        {
            this.context = context;
        }

        public void AddOrUpdate(T item)
        {
            if (item.GetType().IsAssignableTo(typeof(IProduct)) && context.Products is not null)
            {
                var asInterface = item as IProduct;
                if (asInterface is not null)
                {
                    context.Products.Add(new ProductEntity(asInterface));
                    context.SaveChanges();
                }
            }
            if (item.GetType().IsAssignableTo(typeof(IOrderPosition)) && context.OrderPositions is not null)
            {
                var asInterface = item as IOrderPosition;
                if (asInterface is not null)
                {
                    var mapper = new OrderPositionEntityMapper(asInterface);
                    context.OrderPositions.Add(mapper.Entity);
                    context.SaveChanges();
                }
            }
            if (item.GetType().IsAssignableTo(typeof(IOrder)) && context.Orders is not null)
            {
                var asInterface = item as IOrder;
                if (asInterface is not null)
                {
                    var orderEntity = new OrderEntity(asInterface);
                    context.Orders.Add(orderEntity);
                    context.SaveChanges();
                }
            }
        }
    }
}
