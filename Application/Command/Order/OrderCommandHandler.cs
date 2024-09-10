using Application.Services.Ws;
using Domain.Entities;
using Infrastructure.Interfaces;
using MediatR;
namespace Application.Command.Order;

public class OrderCommandHandler : IRequestHandler<OrdineCommand, string>
{
    private readonly IQueService _queService;
    private readonly WsHandler _webSocketHandler;

    public OrderCommandHandler(IQueService queService, WsHandler webSocketHandler)
    {
        _queService = queService;
        _webSocketHandler = webSocketHandler;
    }
    public async Task<string> Handle(OrdineCommand request, CancellationToken cancellationToken)
    {
        var order = new Ordine(2, request.prodotti);

        // Send order to RabbitMQ queue
        await _queService.SendMessageAsync(order);
        
        
        
        // Broadcast the new order to WebSocket clients
        var orderMessage = $"Tavolo {order.Tavolo} ha ordinato {String.Join(",", order.Prodotti.Select(p=>p.Nome))}";
        await _webSocketHandler.BroadcastOrder(orderMessage);

        return order.Id.ToString();
    }
}