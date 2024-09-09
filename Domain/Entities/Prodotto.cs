namespace Domain.Entities;

public class Prodotto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descrizione { get; set; }
    public decimal Prezzo { get; set; }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
    
    public Prodotto(string nome, string descrizione, decimal prezzo, int categoriaId)
    {
        Nome = nome;
        Descrizione = descrizione;
        Prezzo = prezzo;
        CategoriaId = categoriaId;
    }
}