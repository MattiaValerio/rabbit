using Application.Services.Ws;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("ws/orders")]
public class OrderWsController : ControllerBase
{
    private readonly WsHandler _webSocketHandler;

    public OrderWsController(WsHandler webSocketHandler)
    {
        _webSocketHandler = webSocketHandler;
    }

    [HttpGet]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await _webSocketHandler.HandleWebSocketConnection(webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = 400;
        }
    }
}