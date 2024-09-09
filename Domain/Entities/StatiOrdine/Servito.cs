using Domain.Interfaces;

namespace Domain.Entities.StatiOrdine;

public class Servito : IOrderStatus
{
    public void AvanzaStato(Ordine ordine)
    {
        ordine.Stato = new Pagato();
    }

    public void AnnullaOrdine(Ordine ordine)
    {
        throw new NotImplementedException();
    }

    public string GetDescrizione()
    {
        throw new NotImplementedException();
    }
}