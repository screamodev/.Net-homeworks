namespace Module2HW6.Entities;

public class Television : ElectricalAppliance
{
    public Television(string name, double powerConsumption, double price, string brand ) : base(name, powerConsumption)
    {
        Price = price;
        Brand = brand;
    }

    public override double Price { get; set; }
    public override string Brand { get; set; }

    public override void PlugIn()
    {
        IsPluggedIn = true;

        Console.WriteLine($"Television {Brand} {Name} has been plugged in.");
    }
}