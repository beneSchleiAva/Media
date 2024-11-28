using ModelInterface.Interface.ValueObjects;

namespace ModelInterface.Model.ValueObjects
{
    internal class ConcreteOrderId : IOrderId
    {
        public Guid Value { get; private set; }
        public ConcreteOrderId()
        {
            Value = Guid.NewGuid();
        }
    }
}
