namespace ModelInterface.Interface.Elements
{
    public interface IProduct:IDomainElelement
    {
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
    }
}
