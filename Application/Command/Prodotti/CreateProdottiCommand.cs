using MediatR;

namespace Application.Command.Prodotti;

public record CreateProdottiCommand(int id,
                             string nome,
                             string descrizione,
                             decimal prezzo) : IRequest<int>; // return the id of the new product
