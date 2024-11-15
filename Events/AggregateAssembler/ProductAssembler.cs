using ModelInterface.Interface;

namespace Events.AggregateAssembler
{
    internal class ProductAssembler
    {
        public static ProductAggregateRoot AssembleAggregateRoot(IProduct product)
        {
            var productAggregateRoot = new ProductAggregateRoot();
            productAggregateRoot.CreateProduct(product);
           return productAggregateRoot;
        }

       
    }
}
