namespace Module2HW6.Entities;

public class SmartTelevision : Television
{
    public SmartTelevision(string name, double powerConsumption, double price, string brand, string[] smartFeatures)
        : base(name, powerConsumption, price, brand)
    {
        SmartFeatures = smartFeatures;
    }

    protected string[] SmartFeatures { get; set; }

    public override void PlugIn()
    {
        Console.WriteLine($"Smart television {Brand} {Name} has been plugged in.");
    }

    public void DisplayFeatures()
    {
        Console.WriteLine($"Smart TV Features of {Name}:");
        foreach (var feature in SmartFeatures)
        {
            Console.WriteLine(feature);
        }
    }
}