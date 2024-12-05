using ModelInterface.Interface;
using Persistence.Repositories.Abstract;

namespace Persistence.Repositories.Concrete
{
    public class InMemoryRepo<T> : ICommandRepository<T> where T : class
    {
        private static readonly IList<T> items = new List<T>();

        public void AddOrUpdate(T item)
        {
            items.Add(item);
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            return items;
        }
    }
}
