namespace Domain.Entities;

public class Dipendente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Ruolo { get; set; } // Chef, Cameriere, etc.
}