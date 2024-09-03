using System.Text;
using System.Text.Json;
using QueLib.Models;
using RabbitMQ.Client;

namespace QueLib.Server.Services.QueService.Sender;

public class QueSender
{
    private readonly RabbitMqConfig _conf;

    public QueSender(RabbitMqConfig config)
    {
        _conf = config;
    }
    
    public void Send(Persona persona)
    {
        try
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
        
        
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(persona));
            channel.BasicPublish(exchange: "", routingKey: _conf.QueueName, basicProperties: null, body: body);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
}
