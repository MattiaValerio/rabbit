
using Factory.Abstraction;
using Factory.Creator;

Console.WriteLine("Digitare [CAR] per creare un'auto | [BIKE] per creare una bici | [BOAT] per creare una barca.");
string vehicleType = Console.ReadLine();

VehicleCreator Vehicle = vehicleType switch
{
    "car" => new CarCreator(),
    "bike" => new BikeCreator(),
    "boat" => new BoatCreator(),
    _ => throw new ArgumentException("Tipo di veicolo non valido.")
};

Vehicle.GetVehicleWhellsNumber();
Vehicle.CreateVehicle().Start();

