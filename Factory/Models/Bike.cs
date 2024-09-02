using Factory.Interfaces;

namespace Factory.Models;

public class Bike : IVehicle
{
    public int Wheels { get; set; }
    public void Start()
    {
        Console.WriteLine("Pedala, pedala, pedala...");
    }
}