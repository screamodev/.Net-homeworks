public class RootVegetable : Vegetable
{
     public RootVegetable(string name, double calories, double weight, bool isRoot) : base(name, calories, weight)
     {
          IsRoot = isRoot;
     }

     public bool IsRoot { get; set; }
}