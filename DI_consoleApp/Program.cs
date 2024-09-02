
using DI_consoleApp.abstraction;
using DI_consoleApp.Creators;
using DI_consoleApp.Models;

Console.WriteLine("Digitare l'indirizzo di spedizione:");
string address = Console.ReadLine();

Console.WriteLine("Digitare il tipo di spedizione [A]ria | [M]are:");
var shippingType = Console.ReadLine();

ShippingLabelCreator label = shippingType switch
{
    "A" => new AirShippingLabelCreator(),
    "M" => new SeaShippingLabelCreator(),
    _ => throw new ArgumentException("Tipo di spedizione non valido.")
};

Console.WriteLine(label.GetShippingLabel(address));


