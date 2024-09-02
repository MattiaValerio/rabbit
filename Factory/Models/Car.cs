using Factory.Interfaces;

namespace Factory.Models;

public class Car : IVehicle
{
    public int Wheels { get; set; }
    public void Start()
    {
        Console.WriteLine("Brum, brum, brum...");
    }
}