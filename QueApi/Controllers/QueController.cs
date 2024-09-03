using Microsoft.AspNetCore.Mvc;
using QueLib.Models;
using QueLib.Server.Services.QueService;
using QueLib.Server.Services.QueService.Receiver;
using QueLib.Server.Services.QueService.Sender;

namespace QueApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QueController : ControllerBase
{
    private readonly QueSender _senderService;
    private readonly QueReceiver _receiverService;
    private readonly QueReceiverBackgroundService _backgroundService;
    private readonly IHostApplicationLifetime _applicationLifetime;
    private readonly RabbitService _rabbitService;

    public QueController(QueSender senderService, QueReceiver receiverService,RabbitService rabbitService, QueReceiverBackgroundService backgroundService, IHostApplicationLifetime applicationLifetime)
    {
        _senderService = senderService;
        _receiverService = receiverService;
        _backgroundService = backgroundService;
        _applicationLifetime = applicationLifetime;
        _rabbitService = rabbitService;
    }
    
    /// <summary>
    /// Starts listening for messages from the RabbitMQ queue.
    /// </summary>
    /// <returns>A confirmation message.</returns>
    [HttpPost("start-listening")]
    public IActionResult StartListening()
    {
        _rabbitService.ReceiveMessage(message =>
        {
            // Log the received message or handle it accordingly.
            Console.WriteLine($"Received message: {message}");
        });
        return Ok("Started listening for messages");
    }
    
    /// <summary>
    /// Stops listening for messages from the RabbitMQ queue.
    /// </summary>
    /// <returns>A confirmation message.</returns>
    [HttpPost("stop-listening")]
    public IActionResult StopListening()
    {
        _rabbitService.StopReceivingMessages();
        return Ok("Stopped listening for messages");
    }

    /// <summary>
    /// Publishes a message to the RabbitMQ queue.
    /// </summary>
    /// <param name="persona">The message to be published.</param>
    /// <returns>A confirmation message.</returns>
    [HttpPost("publish")]
    public IActionResult PublishMessage([FromBody] Persona persona)
    {
        if (persona is null)
        {
            return BadRequest("Message cannot be null or empty");
        }

        _rabbitService.PublishMessage(persona);
        return Ok("Message published to the queue");
    }
    
    [HttpPost("send")]
    public IActionResult SendMessage(Persona persona)
    {
        _senderService.Send(persona);
        return Ok();
    }
    
    [HttpPost("start-background-receiver")]
    public IActionResult StartBackgroundReceiver()
    {
        _backgroundService.StartAsync(_applicationLifetime.ApplicationStopping);
        
        return Ok("Background receiver started.");
    }

    [HttpPost("stop-background-receiver")]
    public IActionResult StopBackgroundReceiver()
    {
        _backgroundService.StopAsync(_applicationLifetime.ApplicationStopping);
        return Ok("Background receiver stopped.");
    }
}