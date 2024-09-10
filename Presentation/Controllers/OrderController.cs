using Application.Command.Order;
using Application.Command.OrderOfDay;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers;


[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("ordini")]
    public async Task<IActionResult> GetOrdersOfDay([FromQuery] OrdiniDelGiornoCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateOrder([FromBody] OrdineCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}