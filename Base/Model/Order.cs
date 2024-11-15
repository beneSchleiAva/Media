using ModelInterface.Interface;

namespace Base.Model
{
    public class Order : IOrder
    {
        public string Id { get { return Id ?? ""; } private set { Id = value; } }

        public string DisplayName { get { return DisplayName ?? ""; } private set { DisplayName = value; } }

        public IEnumerable<IProduct> Products { get; private set; }=new List<IProduct>();

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
