

using CQRS.Mediatr.Lite;
using ModelInterface.Interface;

namespace Events.Commands
{
    public class IssuedCmd<T> : Command<IdCommandResult>
    {
        public override string Id { get; }
        public override string DisplayName { get; }

        public T? Item{ get; set; }

        public IssuedCmd(T product)
        {
            Item= product;
        }

        public override bool Validate(out string ValidationErrorMessage)
        {
            
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
