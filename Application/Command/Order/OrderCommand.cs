using MediatR;
namespace Application.Command.Order;

// record that rapresent the comand to create a new order
public record OrderCommand(
    string ProductName,
    decimal Price,
    string Table) : IRequest<Guid>; // return the id of the new order