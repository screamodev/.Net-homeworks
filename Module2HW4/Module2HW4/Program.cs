using Module2HW4.entities;
using Module2HW4.utilities;

public class Program
{
    public static void Main()
    {
        Vegetable[] vegetables = new[]
        {
            new Vegetable("Tomato", 32, 100),
            new Vegetable("Pickle", 11, 100),
            new LeafyVegetable("Spinach", 15, 100, true),
            new RootVegetable("Garlic", 16, 100, true),
            new LeafyVegetable("Lettuce", 5, 100, true),
            new RootVegetable("Carrot", 62, 100, true),
            new LeafyVegetable("Cabbage", 42, 100, true)
        };

        Salad salad = new Salad(
            "Greek",
            Salad.CalculateCalories(vegetables),
            Salad.CalculateWeight(vegetables),
            vegetables);

        Console.WriteLine($"Created salad\n");
        PrintSaladIngredients(salad);

        salad.SortVegetablesByName();

        Console.WriteLine($"\nSalad after sort\n");
        PrintSaladIngredients(salad);

        RootVegetable[] rootVegetables = salad.FindRootVegetables(salad);

        Console.WriteLine("\nFounded root vegetables in salad\n");

        foreach (var vegetable in rootVegetables)
        {
            Console.WriteLine($"Name: {vegetable.Name}");
        }
    }

    private static void PrintSaladIngredients(Salad salad)
    {
        Console.WriteLine($"Ingredients of {salad.Name} salad:");
        foreach (var vegetable in salad.Vegetables)
        {
            Console.WriteLine($"Name: {vegetable.Name}");
        }
    }
}