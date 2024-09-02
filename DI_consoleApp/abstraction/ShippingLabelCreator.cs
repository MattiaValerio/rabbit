using DI_consoleApp.Interfaces;

namespace DI_consoleApp.abstraction;

public abstract class ShippingLabelCreator
{
    public abstract ILabel LabelFactoryMethod();

    
    public string GetShippingLabel(string address)
    {
        // Call the factory method to create a label object.
        var label = LabelFactoryMethod();
        label.Address = address;
        
        // Now, use the label.
        return "SHIPPING LABEL CREATOR: " + label.GetLabel();
    }
}