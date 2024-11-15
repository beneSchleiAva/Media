using ModelInterface;
using ModelInterface.Interface;
using Persistence.Entities;

namespace Events.Repositories
{
    public class ProductInMemoryRepo : IProductRepository
    {
        private static readonly IList<Product> _products = new List<Product>();
        public void AddOrUpdate(IProduct product)
        {
            var entityProduct = new Product(product);
            _products.Add(entityProduct);

        }

        public IEnumerable<IProduct> GetOrders(Func<IProduct, bool> predicate)
        {
            return _products;
        }
    }
}
