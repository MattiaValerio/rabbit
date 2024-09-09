namespace Domain.Entities;

public class Tavolo
{
    public Guid Id { get; set; }
    public int Coperti { get; set; }
    public bool Occupato { get; set; }
}