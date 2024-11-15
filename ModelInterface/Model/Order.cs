using ModelInterface.Interface;

namespace ModelInterface.Model
{
    internal class Order : IOrder
    {
        public string Id { get { return Id ?? ""; } private set { Id = value; } }

        public string DisplayName { get { return DisplayName ?? ""; } private set { DisplayName = value; } }

        public IEnumerable<IProduct> Products { get { return Products ?? new List<Product>(); } private set { Products = value; } }
        
        public Order()
        {
            Id = Guid.NewGuid().ToString();
            Products = new List<IProduct>();
        }

        public Order(IEnumerable<IProduct> products)
        {
            Id = Guid.NewGuid().ToString();
            Products = products;
        }

    }
}
