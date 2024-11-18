namespace ModelInterface.Interface
{

    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate);
        void AddOrUpdate(T item);
    }
}

