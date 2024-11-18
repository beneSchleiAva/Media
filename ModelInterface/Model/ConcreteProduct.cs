using ModelInterface.Interface.Elements;

namespace ModelInterface.Model
{
    internal class ConcreteProduct : IProduct
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }


        public ConcreteProduct(string name, string description, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
