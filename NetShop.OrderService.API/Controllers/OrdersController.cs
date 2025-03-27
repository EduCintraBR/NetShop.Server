using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetShop.OrderService.Application.Commands;
using NetShop.OrderService.Application.Queries;

namespace NetShop.OrderService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, null);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _mediator.Send(new GetOrdersQuery());
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            return Ok();
        }
    }

}
