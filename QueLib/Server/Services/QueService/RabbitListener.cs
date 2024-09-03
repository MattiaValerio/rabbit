using Microsoft.Extensions.Hosting;

namespace QueLib.Server.Services.QueService;

public class RabbitListener : BackgroundService
{
    private readonly RabbitService _rabbitService;
    public RabbitListener(RabbitService rabbitService)
    {
        _rabbitService = rabbitService;
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
     _rabbitService.ReceiveMessage(Console.WriteLine);
     
     return Task.CompletedTask;
    }
    
    public override void Dispose()
    {
        _rabbitService.Dispose();
        base.Dispose();
    }
}