namespace QueLib.Models;

public class Persona
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }

    public Persona(string name, string lastname)
    {
        Id = Guid.NewGuid();
        Name = name;
        Lastname = lastname;
    }
}