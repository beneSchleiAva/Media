namespace Persistence.Entities
{
    internal class OrderEntity
    {
        public Guid Id { get; private set; }

        public string DisplayName { get; set;}

        public IEnumerable<OrderPositionEntity> Positions { get;  set; }

        public OrderEntity()
        { }

    }
}
