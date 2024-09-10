using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace Application.Services.Ws;

public class WsHandler
{
    private static ConcurrentDictionary<string, WebSocket> _sockets = new();
    
    public async Task HandleWebSocketConnection(WebSocket webSocket)
    {
        var socketId = Guid.NewGuid().ToString();
        _sockets.TryAdd(socketId, webSocket);

        var buffer = new byte[1024 * 4];
        var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!result.CloseStatus.HasValue)
        {
            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        }

        // Close WebSocket connection
        _sockets.TryRemove(socketId, out WebSocket _);
        await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
    }
    
    
    public async Task BroadcastOrder(string orderMessage)
    {
        var tasks = new List<Task>();
        var buffer = Encoding.UTF8.GetBytes(orderMessage);

        foreach (var socket in _sockets.Values)
        {
            if (socket.State == WebSocketState.Open)
            {
                tasks.Add(socket.SendAsync(new ArraySegment<byte>(buffer, 0, buffer.Length), WebSocketMessageType.Text, true, CancellationToken.None));
            }
        }

        await Task.WhenAll(tasks);
    }
    
}