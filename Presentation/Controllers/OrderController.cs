using Application.Command.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers;


[ApiController]
[Route("[controller]")]
public class OrderController : Controller
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}