using DI_consoleApp.Interfaces;

namespace DI_consoleApp.Models;

public class AirShippingLabel : ILabel
{
    public string Id { get; set; }
    public string Address { get; set; }
    public string GetLabel()
    {
        return "Air Shipping Label: " + Address;
    }
}