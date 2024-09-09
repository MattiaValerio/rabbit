using Domain.Entities;
using MediatR;
namespace Application.Command.Order;

public class OrderCommandHandler : IRequestHandler<OrdineCommand, string>
{
    public Task<string> Handle(OrdineCommand request, CancellationToken cancellationToken)
    {
        Ordine x = new Ordine(request.tavoloId, request.prodotti);
        
        return Task.FromResult(x.Stato.GetDescrizione());
    }
}