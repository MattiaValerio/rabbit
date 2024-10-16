using Domain.Entities;
using MediatR;

namespace Application.Command.OrderOfDay;

public record OrdiniDelGiornoCommand(DateOnly data) :IRequest<List<Ordine>>; // return the id of the new order of the day