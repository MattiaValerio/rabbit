using Domain.Entities;

namespace Domain.Interfaces;

public interface IOrderStatus
{
    void AvanzaStato(Ordine ordine);
    void AnnullaOrdine(Ordine ordine);
    string GetDescrizione();
}