using Microsoft.Extensions.Hosting;

namespace QueLib.Server.Services.QueService.Receiver;

public class QueReceiverBackgroundService : BackgroundService
{
    private readonly QueReceiver _queReceiver;

    public QueReceiverBackgroundService(QueReceiver queReceiver)
    {
        _queReceiver = queReceiver;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Background service started....");
        while (!stoppingToken.IsCancellationRequested)
        {
            _queReceiver.Receive();
            await Task.Delay(1000, stoppingToken); // Adjust the delay as needed
        }
        Console.WriteLine("Background service stopped....");
    }
}