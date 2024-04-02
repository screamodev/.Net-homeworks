namespace Homeworks.Module2HW3.Entities;

public class Chocolate : Sweet
{
    public Chocolate(string name, double weight, string color) : base(name, weight)
    {
        Color = color;
    }

    public string Color { get; set; }

    public override void ShowDescription()
    {
        Console.WriteLine("A sweet, usually brown, food made from cacao seeds");
    }
}