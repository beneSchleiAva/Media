using CQRS.Mediatr.Lite;
using Events.Commands.CreateEntity;
using Events.Queries;
using Microsoft.AspNetCore.Mvc;
using ModelInterface.Interface.Elements;
using ReactApi.UIDto.Product;

namespace ReactApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryService _queryService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, ICommandBus commandBus, IQueryService queryService)
        {
            _logger = logger;
            _commandBus = commandBus;
            _queryService = queryService;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<IEnumerable<ProductUIDto>> Get()
        {
            var list = new List<ProductUIDto>();
            var queryEntities = await _queryService.Query(new GetAllQuery<IProduct>());
            queryEntities.ToList().ForEach(entity => list.Add(new ProductUIDto(entity)));
            return list;

        }

        [HttpPost(Name = "PostProduct")]
        public async Task Post(ProductUIDto input)
        {
            EntityCreateCommand<IProduct> command = new(input);
            var result = await _commandBus.Send(command);
        }
    }
}