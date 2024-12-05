using Autofac;
using CQRS.Mediatr.Lite;
using Events.Commands.CreateEntity;
using Events.Events.EntityCreated;
using Events.EventsStore;
using Events.EventStore;
using Events.Queries;
using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;
using Persistence.Repositories.Abstract;
using Persistence.Repositories.Concrete;

namespace FrontendBase
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

            builder.RegisterType<PersistentCommandRepository<IProduct>>()
                .As<ICommandRepository<IProduct>>()
                .SingleInstance();

            builder.RegisterType<PersistentCommandRepository<IOrder>>()
                .As<ICommandRepository<IOrder>>()
                .SingleInstance();

            builder.RegisterType<PersistentCommandRepository<IOrderPosition>>()
            .As<ICommandRepository<IOrderPosition>>()
           .SingleInstance();

            builder.RegisterType<PersistentQueryRepository<IProduct>>()
            .As<IQueryRepository<IProduct>>()
            .SingleInstance();

            builder.RegisterType<PersistentQueryRepository<IOrder>>()
                .As<IQueryRepository<IOrder>>()
                .SingleInstance();

            builder.RegisterType<PersistentQueryRepository<IOrderPosition>>()
            .As<IQueryRepository<IOrderPosition>>()
           .SingleInstance();
            #endregion

            #region QueryHandlers
            builder.RegisterType<GetAllQueryHandler<IProduct>>()
                .As<QueryHandler<GetAllQuery<IProduct>, IEnumerable<IProduct>>>()
                .SingleInstance();

            builder.RegisterType<GetAllQueryHandler<IOrder>>()
                .As<QueryHandler<GetAllQuery<IOrder>, IEnumerable<IOrder>>>()
                .SingleInstance();

            builder.RegisterType<GetAllQueryHandler<IOrderPosition>>()
                .As<QueryHandler<GetAllQuery<IOrderPosition>, IEnumerable<IOrderPosition>>>()
                .SingleInstance();

            #endregion

            #region EventHandlers


            builder.RegisterType<EntityCreatedEventHandler<EntityCreatedEvent<IOrder>, IOrder>>()
                .As<CQRS.Mediatr.Lite.EventHandler<EntityCreatedEvent<IOrder>>>()
                .SingleInstance();

            builder.RegisterType<EntityCreatedEventHandler<EntityCreatedEvent<IOrderPosition>, IOrderPosition>>().As<CQRS.Mediatr.Lite.EventHandler<EntityCreatedEvent<IOrderPosition>>>().SingleInstance();

            #endregion
            #region CommandHandlers
            builder.RegisterType<EntityCreateCommandHandler<IProduct>>()
                .As<CommandHandler<EntityCreateCommand<IProduct>, IdCommandResult>>();

            builder.RegisterType<EntityCreateCommandHandler<IOrder>>()
                .As<CommandHandler<EntityCreateCommand<IOrder>, IdCommandResult>>();

            builder.RegisterType<EntityCreateCommandHandler<IOrderPosition>>().As<CommandHandler<EntityCreateCommand<IOrderPosition>, IdCommandResult>>();
            #endregion
        }
    }
}
