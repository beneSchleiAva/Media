namespace ModelInterface.Interface
{
    public interface IProduct
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public int Quantity { get; }
    }
}
