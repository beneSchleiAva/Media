using ModelInterface.Interface;

namespace Events.Repositories
{
    public class ProductInMemoryRepo : IProductRepository
    {
        private static readonly IList<IProduct> _products = new List<IProduct>();
        public void AddOrUpdate(IProduct product)
        {
            _products.Add(product);
        }

        public IEnumerable<IProduct> GetOrders(Func<IProduct, bool> predicate)
        {
            return _products;
        }
    }
}
