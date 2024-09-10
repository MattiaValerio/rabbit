namespace Infrastructure.Interfaces;

public interface IQueService
{
    Task PublishAsync<T>(T message);
    Task SubscribeAsync<T>(Func<T, Task> handler);
    Task SendMessageAsync<T>(T message);
}