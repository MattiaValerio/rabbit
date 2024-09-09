using Domain.Entities;
using MediatR;
namespace Application.Command.Order;

// record that rapresent the comand to create a new order
public record OrdineCommand(
    int tavoloId, 
    List<Prodotto> prodotti) : IRequest<string>; // return the id of the new order