using Autofac;
using CQRS.Mediatr.Lite;
using Events.Commands.CreateEntity;
using Events.Events.CreateEntity;
using Events.Events.EntityCreated;
using Events.EventsStore;
using Events.EventStore;
using Events.Queries;
using ModelInterface.Interface.Elements;
using Persistence.Repositories.Abstract;
using Persistence.Repositories.Concrete;

namespace Media.Dependency
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            #region commmon
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
            builder.RegisterType<InMemEventStore>()
                .As<IEventsStore>()
                .SingleInstance();
            #endregion

            #region Storage

            builder.RegisterType<InMemoryRepo<IProduct>>()
                .As<IRepository<IProduct>>()
                .SingleInstance();

            builder.RegisterType<InMemoryRepo<IOrder>>()
                .As<IRepository<IOrder>>()
                .SingleInstance();

            #endregion

            #region QueryHandlers
            builder.RegisterType<GetAllQueryHandler<IProduct>>()
                .As<QueryHandler<GetAllQuery<IProduct>, IEnumerable<IProduct>>>()
                .SingleInstance();

            builder.RegisterType<GetAllQueryHandler<IOrder>>()
                .As<QueryHandler<GetAllQuery<IOrder>, IEnumerable<IOrder>>>()
                .SingleInstance();

            #endregion

            #region EventHandlers

            builder.RegisterType<CreateEventHandler<CreateEvent<IProduct>, IProduct>>()
                .As<CQRS.Mediatr.Lite.EventHandler<CreateEvent<IProduct>>>()
                .SingleInstance();

            builder.RegisterType<CreateEventHandler<CreateEvent<IOrder>, IOrder>>()
                .As<CQRS.Mediatr.Lite.EventHandler<CreateEvent<IOrder>>>()
                .SingleInstance();

            builder.RegisterType<EntityCreatedEventHandler<EntityCreatedEvent<IOrder>, IOrder>>()
                .As<CQRS.Mediatr.Lite.EventHandler<EntityCreatedEvent<IOrder>>>()
                .SingleInstance();

            #endregion
            #region CommandHandlers
            builder.RegisterType<EntityCreateCommandHandler<IProduct>>()
                .As<CommandHandler<EntityCreateCommand<IProduct>, IdCommandResult>>();

            builder.RegisterType<EntityCreateCommandHandler<IOrder>>()
                .As<CommandHandler<EntityCreateCommand<IOrder>, IdCommandResult>>();
            #endregion
        }
    }
}
