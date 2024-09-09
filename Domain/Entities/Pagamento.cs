namespace Domain.Entities;

public class Pagamento
{
    public int Id { get; set; }
    public int OrdineId { get; set; }
    public Ordine Ordine { get; set; }
    public decimal Importo { get; set; }
    public string MetodoPagamento { get; set; } // Es. Contanti, Carta
    public DateTime DataPagamento { get; set; }
}