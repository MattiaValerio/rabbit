using Factory.Abstraction;
using Factory.Interfaces;
using Factory.Models;

namespace Factory.Creator;

public class BikeCreator: VehicleCreator
{
    public override IVehicle CreateVehicle()
    {
        var bike = new Bike
        {
            Wheels = 2
        };

        return bike;
    }
}