using MediatR;
namespace Application.Command.Order;

public class OrderCommandHandler : IRequestHandler<OrderCommand, Guid>
{
    public Task<Guid> Handle(OrderCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Order x = new Domain.Entities.Order(request.ProductName, request.Price, request.Table);
        
        return Task.FromResult(x.Id);
    }
}