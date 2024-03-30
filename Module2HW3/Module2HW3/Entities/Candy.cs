namespace Homeworks.Module2HW3.Entities;

public class Candy : Sweet, ICandy
{
    public Candy(string name, double weight, string flavor) : base(name, weight)
    {
        Flavor = flavor;
    }

    public string Flavor { get; set; }

    public override void ShowDescription()
    {
        Console.WriteLine("A confection made with sugar and often flavoring and filling");
    }
}