namespace Persistence.Repositories.Abstract
{

    public interface ICommandRepository<T> where T : class
    {
        void AddOrUpdate(T item);
    }
}

