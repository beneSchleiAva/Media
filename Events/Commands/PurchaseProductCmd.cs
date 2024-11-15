
using CQRS.Mediatr.Lite;
using ModelInterface.Interface;

namespace Events.Commands
{
    public class PurchaseProductCmd : Command<IdCommandResult>
    {
        public override string Id { get; }
        public override string DisplayName { get; }

        public IProduct? Product { get; set; }

        public PurchaseProductCmd(IProduct product)
        {
            Product = product;
        }

        public override bool Validate(out string ValidationErrorMessage)
        {
            
            if (Product != null)
            {
                ValidationErrorMessage = "Valid Product";
                return true;
            }
            ValidationErrorMessage = "InValid Product";
            return false;
        }
    }
}
