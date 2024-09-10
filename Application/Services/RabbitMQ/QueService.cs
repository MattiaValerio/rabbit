using System.Text;
using System.Text.Json;
using Infrastructure.Interfaces;
using RabbitMQ.Client;

namespace Infrastructure.Services.RabbitMQ;

public class QueService : IQueService, IDisposable
{

    private readonly RabbitOptions _options;
    private IConnection _connection;
    private IModel _channel;
    public QueService(RabbitOptions options)
    {
        _options = options;
        CreateConnection();
    }
    
    
    private void CreateConnection()
    {
        if (_connection == null || !_connection.IsOpen)
        {
            var factory = new ConnectionFactory() { HostName = _options.Host };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: _options.QueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }
    }
    
    public Task SendMessageAsync<T>(T message)
    {
        // Ensure the connection is established
        if (!_channel.IsOpen)
        {
            CreateConnection();
        }

        var msg = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(msg);

        _channel.BasicPublish(exchange: "",
            routingKey: _options.QueName,
            basicProperties: null,
            body: body);

        return Task.CompletedTask;
    }
    
    public Task PublishAsync<T>(T message)
    {
        throw new NotImplementedException();
    }

    public Task SubscribeAsync<T>(Func<T, Task> handler)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        if (_channel != null)
        {
            _channel.Close();
            _channel.Dispose();
        }

        if (_connection != null)
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}