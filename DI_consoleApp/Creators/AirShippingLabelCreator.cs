using DI_consoleApp.abstraction;
using DI_consoleApp.Interfaces;
using DI_consoleApp.Models;

namespace DI_consoleApp.Creators;

public class AirShippingLabelCreator : ShippingLabelCreator
{
    public override ILabel LabelFactoryMethod()
    {
        return new AirShippingLabel();
    }
}