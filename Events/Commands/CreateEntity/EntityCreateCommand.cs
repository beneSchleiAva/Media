﻿

using CQRS.Mediatr.Lite;
using ModelInterface.Factories;
using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;

namespace Events.Commands.CreateEntity
{
    public class EntityCreateCommand<T> : Command<IdCommandResult>
    {
        public override string Id { get; }
        public override string DisplayName { get; }
        public T? Item { get; set; }


        public EntityCreateCommand(T item)
        {
            Id = Guid.NewGuid().ToString();
            DisplayName = nameof(EntityCreateCommand<T>);
            Item = item;
        }
        public EntityCreateCommand(string productName, string productDescription, decimal productPrice)
        {
            Id = Guid.NewGuid().ToString();
            DisplayName = nameof(EntityCreateCommand<T>);
            if (typeof(T) == typeof(IProduct))
                Item = (T?)ProductFactory.Create(productName, productDescription, productPrice);
        }

        public EntityCreateCommand(IEnumerable<IOrderPosition> positions)
        {
            //1
            Id = Guid.NewGuid().ToString();
            DisplayName = nameof(EntityCreateCommand<T>);
            if (typeof(T) == typeof(IOrder))
                Item = (T?)OrderFactory.Create(positions);
        }

        public override bool Validate(out string ValidationErrorMessage)
        {
            //2
            if (Item != null)
            {
                ValidationErrorMessage = "Valid";
                return true;
            }
            ValidationErrorMessage = "InValid";
            return false;
        }
    }
}
