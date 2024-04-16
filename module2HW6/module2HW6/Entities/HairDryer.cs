using Module2HW6.Entities.Interfaces;

namespace Module2HW6.Entities;

public class HairDryer : ElectricalAppliance, IProduct
{
    public HairDryer(string name, double powerConsumption, double price, string brand ) : base(name, powerConsumption)
    {
        Price = price;
        Brand = brand;
    }

    public double Price { get; set; }
    public string Brand { get; set; }

    public override void PlugIn()
    {
        IsPluggedIn = true;

        Console.WriteLine($"Hairdryer {Brand} {Name} has been plugged in.");
    }
}