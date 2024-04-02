namespace Module2HW4.Entities;

public class Potato : RootVegetable
{
    public Potato(double calories, double weight, bool isRoot, bool isPeeled) : base("Potato", calories, weight, isRoot)
    {
        IsRoot = isRoot;
        IsPeeled = isPeeled;
    }

    public bool IsRoot { get; set; }
    public bool IsPeeled { get; set; }
}