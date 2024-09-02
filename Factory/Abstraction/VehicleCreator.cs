using Factory.Interfaces;

namespace Factory.Abstraction;

public abstract class VehicleCreator
{
    public abstract IVehicle CreateVehicle();
    
    public void GetVehicleWhellsNumber()
    {
        var vehicle = CreateVehicle();
        Console.WriteLine($"The vehicle has {vehicle.Wheels} wheels.");
    }
    
}