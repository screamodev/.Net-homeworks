namespace Homeworks.Module2HW3.Entities;

public abstract class Sweet
{
    protected Sweet(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public string Name { get; set; }
    public double Weight { get; set; }

    public virtual void ShowDescription()
    {
    }
}