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
            var queryProducts = await _queryService.Query(new GetAllQuery<IProduct>());
            queryProducts.ToList().ForEach(product => list.Add(new ProductUIDto(product)));
            return list;

        }

        [HttpPost(Name = "PostProduct")]
        public async Task<IProduct> Post(ProductUIDto product)
        {
                EntityCreateCommand<IProduct> productCmd = new(product);
            var result = await _commandBus.Send(productCmd);
            return product;
        }
    }
}