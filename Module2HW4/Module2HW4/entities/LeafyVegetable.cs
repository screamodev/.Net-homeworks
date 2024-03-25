namespace Module2HW4.entities;

public class LeafyVegetable : Vegetable
{
    public LeafyVegetable(string name, double calories, double weight, bool isLeafy) : base(name, calories, weight)
    {
        IsLeafy = isLeafy;
    }

    public bool IsLeafy { get; set; }
}