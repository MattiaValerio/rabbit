using System.Text;
using QueLib.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace QueLib.Server.Services.QueService;

public class RabbitService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private EventingBasicConsumer _consumer;
    private readonly RabbitMqConfig _conf;

    public RabbitService(RabbitMqConfig conf)
    {
        _conf = conf;
        var factory = new ConnectionFactory
        {
            HostName = _conf.HostName
        };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _consumer = new EventingBasicConsumer(_channel);
        _channel.QueueDeclare(queue: _conf.QueueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    public void PublishMessage(Persona persona)
    {
        
        var body = Encoding.UTF8.GetBytes(persona.ToString());
        _channel.BasicPublish(exchange: "",
            routingKey: _conf.QueueName,
            basicProperties: null,
            body: body);
    }
    
    public void ReceiveMessage(Action<string> handleMessage)
    {
        _consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            handleMessage(message);
        };

        _channel.BasicConsume(queue: _conf.QueueName,
            autoAck: true,
            consumer: _consumer);
    }
    
    public void StopReceivingMessages()
    {
        if (_consumer != null)
        {
            _channel.BasicCancel(_consumer.ConsumerTags.FirstOrDefault());
        }
    }
    
    public void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
    }
    
}