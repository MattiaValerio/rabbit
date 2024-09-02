using DI_consoleApp.Interfaces;

namespace DI_consoleApp.Models;

public class SeaShippingLabel : ILabel
{
    public string Address { get; set; }
    public string ShipId { get; set; }
    public string Bay { get; set; }

    
    public SeaShippingLabel()
    {
        ShipId = "SHIP" + new Random().Next(10000000, 99999999);
        Bay = "BAY" + new Random().Next(1, 100);
    }
    
    public string GetLabel()
    {
        return "Sea Shipping Label: " + Address + " " + ShipId + " " + Bay;
    }
}