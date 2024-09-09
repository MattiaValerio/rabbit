using Domain.Interfaces;

namespace Domain.Entities.StatiOrdine;

public class Annullato : IOrderStatus
{
    public void AvanzaStato(Ordine ordine)
    {
        throw new NotImplementedException();
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