using Factory.Abstraction;
using Factory.Interfaces;
using Factory.Models;

namespace Factory.Creator;

public class BoatCreator : VehicleCreator
{
    public override IVehicle CreateVehicle()
    {
        var boat = new Boat
        {
            Wheels = 0
        };

        return boat;
    }
}