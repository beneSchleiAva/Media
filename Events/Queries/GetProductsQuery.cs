using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Mediatr.Lite;
using ModelInterface.Interface;

namespace Events.Queries
{
    public class GetProductsQuery : Query<IEnumerable<IProduct>>
    {
        public override string DisplayName => nameof(GetProductsQuery);

        public override string Id { get; }

        public GetProductsQuery()
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
