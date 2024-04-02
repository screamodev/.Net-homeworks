using Module2HW4.Entities;
using Module2HW4.Utilities;

public class Program
{
    public static void Main()
    {
        Vegetable[] vegetables = new[]
        {
            new Vegetable("Tomato", 32, 100),
            new Potato(11, 100, true, true),
            new LeafyVegetable("Spinach", 15, 100, true),
            new RootVegetable("Garlic", 16, 100, true),
            new LeafyVegetable("Lettuce", 5, 100, true),
            new RootVegetable("Carrot", 62, 100, true),
            new LeafyVegetable("Cabbage", 42, 100, true)
        };

        var calories = Salad.CalculateCalories(vegetables);
        var weight = Salad.CalculateWeight(vegetables);

        Salad salad = new Salad(
            "Greek",
            calories,
            weight,
            vegetables);
        Console.WriteLine($"Created {salad.Name} salad vegetables: ");
        salad.PrintSaladIngredients();

        salad.SortVegetablesByName();
        Console.WriteLine($"\n{salad.Name} salad vegetables after sort: ");
        salad.PrintSaladIngredients();

        RootVegetable[] rootVegetables = salad.FindRootVegetables(salad);
        Console.WriteLine($"\nFounded root vegetables in {salad.Name} salad: ");
        foreach (var vegetable in rootVegetables)
        {
            Console.WriteLine($"Name: {vegetable.Name}");
        }
    }
}