using Base.Model;
using Commands;
using CQRS.Mediatr.Lite;
using Events.Eventshandler;
using Events.EventStore;

namespace ConsoleCmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var store = new InMemEventStore();
            var requestHandler = new ProductPurchasedEventHandler(store);
            var commandBus = new CommandBus(requestHandlerResolver);
            var product = new Product("ProductName", "ProductDescription", 12345);
            PurchaseProductCmd command = new(product);


            IdCommandResult result = await _commandBus.Send(command);
            return new CreatedResult($"api/orders/{result.Id}", result.Id);
        }
    }
}
