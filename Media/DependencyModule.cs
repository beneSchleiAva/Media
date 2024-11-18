using Autofac;
using CQRS.Mediatr.Lite;
using Events.Commands.CreateEntity;
using Events.Events.CreateEntity;
using Events.EventsStore;
using Events.EventStore;
using Events.Queries;
using Events.Repositories;
using ModelInterface.Interface;
using ModelInterface.Interface.Elements;
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

            // Repositories
            builder.RegisterType<InMemoryRepo<IProduct>>()
                .As<IRepository<IProduct>>()
                .SingleInstance();

            builder.RegisterType<InMemoryRepo<IOrder>>()
                .As<IRepository<IOrder>>()
                .SingleInstance();

            // QueryHandlers
            builder.RegisterType<GetAllQueryHandler<IProduct>>()
                .As<QueryHandler<GetAllQuery<IProduct>, IEnumerable<IProduct>>>()
                .SingleInstance();

            builder.RegisterType<GetAllQueryHandler<IOrder>>()
                .As<QueryHandler<GetAllQuery<IOrder>, IEnumerable<IOrder>>>()
                .SingleInstance();

            // CreateEventHandlers

            builder.RegisterType<CreateEventHandler<CreateEvent<IProduct>, IProduct>>()
    .As<CQRS.Mediatr.Lite.EventHandler<CreateEvent<IProduct>>>()
    .SingleInstance();

            builder.RegisterType<CreateEventHandler<CreateEvent<IOrder>, IOrder>>()
.As<CQRS.Mediatr.Lite.EventHandler<CreateEvent<IOrder>>>()
.SingleInstance();

            // CreateCommandHandlers
            builder.RegisterType<EntityCreateCommandHandler<IProduct>>()
                .As<CommandHandler<EntityCreateCommand<IProduct>, IdCommandResult>>();

            builder.RegisterType<EntityCreateCommandHandler<IOrder>>()
                            .As<CommandHandler<EntityCreateCommand<IOrder>, IdCommandResult>>();
        }
    }
}
