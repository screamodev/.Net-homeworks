namespace Homeworks.Module2HW3.Entities;

public class ChocolateCandy : Sweet, IChocolate, ICandy
{
    public ChocolateCandy(string name, double weight, string color, string flavor) : base(name, weight)
    {
        Color = color;
        Flavor = flavor;
    }

    public string Color { get; set; }
    public string Flavor { get; set; }
}