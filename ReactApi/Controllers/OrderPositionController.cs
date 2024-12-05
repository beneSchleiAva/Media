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
            var queryEntities = await _queryService.Query(new GetAllQuery<IOrderPosition>());
            queryEntities.ToList().ForEach(entity => list.Add(new OrderPositionUIDto(entity)));
            return list;

        }

        [HttpPost(Name = "PostOrderPosition")]
        public async Task Post(OrderPositionUIDto input)
        {
            EntityCreateCommand<IOrderPosition> command = new(input);
            var result = await _commandBus.Send(command);
        }
    }
}