using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Infrastructure.Services.RabbitMQ;

public class QueConsumerService
{
    private readonly RabbitOptions _options;
    public QueConsumerService(RabbitOptions options)
    {
        _options = options;
    }

    public void StartConsuming<T>()
    {
        var factory = new ConnectionFactory() { HostName = _options.Host };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
            
        channel.QueueDeclare(queue: _options.QueName,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var order = JsonSerializer.Deserialize<T>(message);
            // Process the order here
        };

        channel.BasicConsume(queue: _options.QueName,
            autoAck: true,
            consumer: consumer);
    }
}