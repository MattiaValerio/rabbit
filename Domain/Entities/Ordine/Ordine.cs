using Domain.Entities.StatiOrdine;
using Domain.Interfaces;

namespace Domain.Entities;

public class Ordine
{
    public Guid Id { get; set; }
    public int TavoloId { get; set; }
    public Tavolo Tavolo { get; set; }
    public List<Prodotto> Prodotti { get; set; }
    public decimal ImportoTotale { get; set; }
    public IOrderStatus Stato { get; set; } // in preparazione, servito, pagato, annullato.
    public DateTime DataOrdine { get; set; }


    public Ordine(int tavoloId, List<Prodotto> prodotti)
    {
        Id = Guid.NewGuid();
        TavoloId = tavoloId;
        Prodotti = prodotti;
        ImportoTotale = prodotti.Sum(p => p.Prezzo);
        Stato = new Preparazione();
        DataOrdine = DateTime.Now;
    }
    
    public void AvanzaStato()
    {
        Stato.AvanzaStato(this);
    }

    public void AnnullaOrdine()
    {
        Stato.AnnullaOrdine(this);
    }

    public string GetDescrizioneStato()
    {
        return Stato.GetDescrizione();
    }
}