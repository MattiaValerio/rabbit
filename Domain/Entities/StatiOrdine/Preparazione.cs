using Domain.Interfaces;

namespace Domain.Entities.StatiOrdine;

public class Preparazione : IOrderStatus
{
    public void AvanzaStato(Ordine ordine)
    {
        ordine.Stato = new Servito();
    }

    public void AnnullaOrdine(Ordine ordine)
    {
        throw new NotImplementedException();
    }

    public string GetDescrizione()
    {
        return "In preparazione";
    }
}