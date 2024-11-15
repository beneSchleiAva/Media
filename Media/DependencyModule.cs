using Autofac;
using CQRS.Mediatr.Lite;
using Events.Commands;
using Events.Events;
using Events.Eventshandler;
using Events.EventsStore;
using Events.EventStore;
using Events.Queries;
using Events.QueryHandlers;
using Events.Repositories;
using ModelInterface.Interface;
namespace Media
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // Infrastructure
            builder.RegisterType<ProductInMemoryRepo>()
                .As<IProductRepository>()
                .SingleInstance();
            builder.RegisterType<InMemEventStore>()
                .As<IEventsStore>()
                .SingleInstance();

            // CQRS Resolver
            builder.Register(ctx =>
            {
                var componentContext = ctx.Resolve<IComponentContext>();
                return new RequestHandlerResolver(requiredType => componentContext.Resolve(requiredType));
            })
          .As<IRequestHandlerResolver>();

            //// Queries
            builder.RegisterType<GetProductsQueryHandler>()
                .As<QueryHandler<GetProductsQuery, IEnumerable<IProduct>>>()
                .SingleInstance();

            builder.RegisterType<QueryService>()
                .As<IQueryService>();
            //builder.RegisterType<GetOrderQueryHandler>()
            //    .As<QueryHandler<GetOrderQuery, OrderDto>>()
            //    .SingleInstance();


            // Events
            builder.RegisterType<ProductPurchasedEventHandler>()
                .As<CQRS.Mediatr.Lite.EventHandler<ProductPurchasedEvent>>()
                .SingleInstance();

            builder.RegisterType<EventBus>()
                .As<IEventBus>();

            // Commands
            builder.RegisterType<PurchaseProductCmdHandler>()
                .As<CommandHandler<PurchaseProductCmd, IdCommandResult>>();
            builder.RegisterType<CommandBus>()
                .As<ICommandBus>();
        }
    }
}
