
using CQRS.Mediatr.Lite;

namespace Events.Queries
{
    public class GetAllQuery<T> : Query<IEnumerable<T>>
    {
        public override string DisplayName => nameof(GetAllQuery<T>);

        public override string Id { get; }

        public GetAllQuery()
        {
            Id = Guid.NewGuid().ToString();
        }

        public override bool Validate(out string ValidationErrorMessage)
        {
            ValidationErrorMessage = null;
            return true;
        }
    }
}
