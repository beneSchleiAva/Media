using CQRS.Mediatr.Lite;
using Events.Commands.CreateEntity;
using Events.Queries;
using Microsoft.AspNetCore.Mvc;
using ModelInterface.Interface.Aggregates;
using ReactApi.UIDto.Order;

namespace ReactApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderPositionController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryService _queryService;
        private readonly ILogger<OrderPositionController> _logger;

        public OrderPositionController(ILogger<OrderPositionController> logger, ICommandBus commandBus, IQueryService queryService)
        {
            _logger = logger;
            _commandBus = commandBus;
            _queryService = queryService;
        }

        [HttpGet(Name = "GetOrderPosition")]
        public async Task<IEnumerable<OrderPositionUIDto>> Get()
        {
            var list = new List<OrderPositionUIDto>();
            var queryProducts = await _queryService.Query(new GetAllQuery<IOrderPosition>());
            queryProducts.ToList().ForEach(product => list.Add(new OrderPositionUIDto(product)));
            return list;

        }

        [HttpPost(Name = "PostOrderPosition")]
        public async Task<IOrderPosition> Post(OrderPositionUIDto position)
        {
                EntityCreateCommand<IOrderPosition> orderPositionCommand = new(position);
            var result = await _commandBus.Send(orderPositionCommand);
            return position;
        }
    }
}