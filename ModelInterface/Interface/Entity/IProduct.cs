using ModelInterface.Interface.ValueObjects;

namespace ModelInterface.Interface.Elements
{
    public interface IProduct
    {
        public IProductId? ProductId { get; }
        public string? Name { get; }
        public string? Description { get; }
        public IProductPrice? Price { get; }
    }
}
