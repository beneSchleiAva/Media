using CQRS.Mediatr.Lite;
using Events.Commands.CreateEntity;
using Events.Queries;
using Microsoft.AspNetCore.Mvc;
using ModelInterface.Interface.Elements;
using ReactApi.UIDto.Order;

namespace ReactApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryService _queryService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger, ICommandBus commandBus, IQueryService queryService)
        {
            _logger = logger;
            _commandBus = commandBus;
            _queryService = queryService;
        }

        [HttpGet(Name = "GetOrders")]
        public async Task<IEnumerable<OrderUIDto>> Get()
        {
            var list = new List<OrderUIDto>();
            var queryProducts = await _queryService.Query(new GetAllQuery<IOrder>());
            queryProducts.ToList().ForEach(product => list.Add(new OrderUIDto(product)));
            return list;
        }

        [HttpPost(Name = "PostOrder")]
        public async Task<IOrder> Post(OrderUIDto position)
        {
                EntityCreateCommand<IOrder> orderPositionCommand = new(position);
            var result = await _commandBus.Send(orderPositionCommand);
            return position;
        }
    }
}