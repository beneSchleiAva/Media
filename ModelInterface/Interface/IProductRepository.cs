namespace ModelInterface.Interface
{

    public interface IProductRepository
    {
        IEnumerable<IProduct> GetOrders(Func<IProduct, bool> predicate);
        void AddOrUpdate(IProduct order);
    }
}

