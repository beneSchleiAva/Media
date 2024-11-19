using Microsoft.AspNetCore.Components;
using ModelInterface.Interface.Aggregates;

namespace Media.Components
{
    public partial class OrderPositionTable
    {
        [Parameter]
        public IEnumerable<IOrderPosition>? OrderPositions{ get; set; }
    }
}
