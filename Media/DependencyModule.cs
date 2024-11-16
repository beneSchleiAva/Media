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

            // Common 

            // Storage
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

            builder.RegisterType<EventBus>()
       .As<IEventBus>();



            builder.RegisterType<QueryService>()
                .As<IQueryService>();

            builder.RegisterType<CommandBus>()
    .As<ICommandBus>();

            // Infrastructure
            builder.RegisterType<ProductInMemoryRepo>()
                .As<IProductRepository>()
                .SingleInstance();

            builder.RegisterType<InMemoryRepo<IProduct>>()
                .As<IRepository<IProduct>>()
                .SingleInstance();

            // Queries
            builder.RegisterType<GetProductsQueryHandler>()
                .As<QueryHandler<GetProductsQuery, IEnumerable<IProduct>>>()
                .SingleInstance();


            builder.RegisterType<GetAllQueryHandler<IProduct>>()
                .As<QueryHandler<GetAllQuery<IProduct>, IEnumerable<IProduct>>>()
                .SingleInstance();


            // Events
            builder.RegisterType<ProductPurchasedEventHandler>()
                .As<CQRS.Mediatr.Lite.EventHandler<ProductPurchasedEvent>>()
                .SingleInstance();

            builder.RegisterType<IssuedEventHandler<IssuedEvent<IProduct>, IProduct>>()
    .As<CQRS.Mediatr.Lite.EventHandler<IssuedEvent<IProduct>>>()
    .SingleInstance();


            // Commands
            builder.RegisterType<PurchaseProductCmdHandler>()
                .As<CommandHandler<PurchaseProductCmd, IdCommandResult>>();
            builder.RegisterType<PurchaseProductCmdHandler>()
    .As<CommandHandler<PurchaseProductCmd, IdCommandResult>>();


            builder.RegisterType<IssuedCmdHandler<IProduct>>()
                .As<CommandHandler<IssuedCmd<IProduct>, IdCommandResult>>();
            builder.RegisterType<PurchaseProductCmdHandler>()
    .As<CommandHandler<PurchaseProductCmd, IdCommandResult>>();

        }
    }
}
