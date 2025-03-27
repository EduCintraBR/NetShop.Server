using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetShop.CatalogService.Application.Commands;
using NetShop.CatalogService.Application.Queries;

namespace NetShop.CatalogService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProducts), new { id = productId }, null);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] GetProductByIdQuery query)
        {
            var product = await _mediator.Send(query);
            return Ok(product);
        }
    }

}
