using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace QueLib.Server.Services.QueService.Receiver;

public class QueReceiver
{
    private readonly RabbitMqConfig _conf;

    public QueReceiver(RabbitMqConfig config)
    {
        _conf = config;
    }
    
    public void Receive()
    {
        var factory = new ConnectionFactory() { HostName = _conf.HostName };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(
            queue: _conf.QueueName, 
            durable: false, 
            exclusive: false,
            autoDelete: false,
            arguments: null);
        
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("Received {0}", message);
        };
        channel.BasicConsume(queue: _conf.QueueName, autoAck: true, consumer: consumer);
    }
}