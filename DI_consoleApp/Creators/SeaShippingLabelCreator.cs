using DI_consoleApp.abstraction;
using DI_consoleApp.Interfaces;
using DI_consoleApp.Models;

namespace DI_consoleApp.Creators;

public class SeaShippingLabelCreator : ShippingLabelCreator
{   
    public override ILabel LabelFactoryMethod()
    {
        return new SeaShippingLabel();
    }
}