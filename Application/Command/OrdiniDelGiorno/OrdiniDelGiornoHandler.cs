using Domain.Entities;
using MediatR;

namespace Application.Command.OrderOfDay;

public class OrdiniDelGiornoHandler : IRequestHandler<OrdiniDelGiornoCommand, List<Ordine>>
{
    public Task<List<Ordine>> Handle(OrdiniDelGiornoCommand request, CancellationToken cancellationToken)
    {
        List<Ordine> ordini = new List<Ordine>();
        
        ordini.Add(new Ordine(1, new List<Prodotto>()
        {
            new Prodotto("Pasta al pomodoro", "Pasta al pomodoro", 5, 1),
            new Prodotto("Pasta al ragù", "Pasta al ragù", 6, 1),
            new Prodotto("Pasta al pesto", "Pasta al pesto", 7, 1),
            new Prodotto("Pasta al tonno", "Pasta al tonno", 8, 1),
        }));
        
        ordini.Add(new Ordine(2, new List<Prodotto>()
        {
            new Prodotto("Pizza Margherita", "Pizza Margherita", 5, 2),
            new Prodotto("Pizza Capricciosa", "Pizza Capricciosa", 6, 2),
            new Prodotto("Pizza Quattro Stagioni", "Pizza Quattro Stagioni", 7, 2),
            new Prodotto("Pizza Quattro Formaggi", "Pizza Quattro Formaggi", 8, 2),
        }));
        
        
        return Task.FromResult(ordini);
    }
}