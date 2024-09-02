using Microsoft.AspNetCore.Mvc;
using QueLib.Models;
using QueLib.Server.Services.QueService.Receiver;
using QueLib.Server.Services.QueService.Sender;

namespace QueApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QueController : ControllerBase
{
    private readonly QueSender _senderService;
    private readonly QueReceiver _receiverService;

    public QueController(QueSender senderService, QueReceiver receiverService)
    {
        _senderService = senderService;
        _receiverService = receiverService;
    }

    [HttpGet("receive")]
    public IActionResult ReceiveMessages()
    {
        _receiverService.Receive();
        return Ok();
    }
    
    [HttpPost("send")]
    public IActionResult SendMessage(Persona persona)
    {
        _senderService.Send(persona);
        return Ok();
    }
}