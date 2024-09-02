using Factory.Abstraction;
using Factory.Interfaces;
using Factory.Models;

namespace Factory.Creator;

public class CarCreator : VehicleCreator
{
    public override IVehicle CreateVehicle()
    {
        var car = new Car
        {
            Wheels = 4
        };

        return car;
    }
}