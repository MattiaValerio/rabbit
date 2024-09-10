using Domain.Entities;
using Infrastructure.Interfaces;
using MediatR;
namespace Application.Command.Order;

public class OrderCommandHandler : IRequestHandler<OrdineCommand, string>
{
    private readonly IQueService _queService;

    public OrderCommandHandler(IQueService queService)
    {
        _queService = queService;
    }
    public async Task<string> Handle(OrdineCommand request, CancellationToken cancellationToken)
    {
        var order = new Ordine(2, request.prodotti);

        // Send order to RabbitMQ queue
        await _queService.SendMessageAsync(order);

        return order.Id.ToString();
    }
}