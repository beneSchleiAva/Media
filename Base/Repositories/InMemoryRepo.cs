using ModelInterface.Interface;

namespace Events.Repositories
{
    public class InMemoryRepo<T> : IRepository<T> where T : class
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
