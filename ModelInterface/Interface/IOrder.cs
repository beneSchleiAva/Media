namespace ModelInterface.Interface
{
    public interface IOrder
    {
        public string Id { get; }
        public string DisplayName { get; }
        public IEnumerable<IProduct> Products { get; }
    }
}
