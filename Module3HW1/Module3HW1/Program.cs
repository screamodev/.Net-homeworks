using Module3HW1.Data;
using Module3HW1.Entities;

public class Program
{
    public static void Main()
    {
        MyCollection<Product> products = new MyCollection<Product>(new Product[]
        {
            new ("Apple", 17),
            new ("Watermelon", 20),
            new ("Peach", 25),
        });

        products.Add(new Product("Blueberry", 140));
        products.Add(new Product[]
        {
            new ("Cherry", 80),
            new ("Cabbage", 5)
        });

        Console.WriteLine($"Products count: {products.Count()}\n");

        products.Sort(new SortPriceAscendingHelper());

        Console.WriteLine("Products sorted by price:\n");
        foreach (var product in products)
        {
            Console.WriteLine($"Name: {product.Name} Price: {product.Price}");
        }

        products.SetDefaultAt(0);

        Console.WriteLine("\nSet first product to default:\n");
        foreach (var product in products)
        {
            Console.WriteLine($"Name: {product.Name} Price: {product.Price}");
        }
    }
}