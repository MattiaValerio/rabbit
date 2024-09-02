using Factory.Interfaces;

namespace Factory.Models;

public class Boat : IVehicle
{
    public int Wheels { get; set; }
    public void Start()
    {
        Console.WriteLine("Chug, chug, chug...");
    }
}