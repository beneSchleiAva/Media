using ModelInterface.Interface.Elements;
using Persistence.Entities.Concrete;
using Persistence.Entities.Concrete.Context;
using Persistence.Repositories.Abstract;

namespace Persistence.Repositories.Concrete
{
    public class PersistentDatabaseRepository<T> : IRepository<T> where T : class
    {
        private readonly EntityContext context;
        public PersistentDatabaseRepository(EntityContext context)
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
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            if (typeof(T).IsAssignableTo(typeof(IProduct)) && context.Products is not null)
                return (IEnumerable<T>)context.Products.ToList();
            return new List<T>();
        }
    }
}
