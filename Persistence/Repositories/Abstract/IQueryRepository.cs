namespace Persistence.Repositories.Abstract
{

    public interface IQueryRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate);
    }
}

