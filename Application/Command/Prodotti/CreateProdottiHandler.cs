using MediatR;

namespace Application.Command.Prodotti;

public class CreateProdottiCommandHandler : IRequestHandler<CreateProdottiCommand, int>
{
    public Task<int> Handle(CreateProdottiCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}