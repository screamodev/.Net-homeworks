using Homeworks.Module2HW3.Entities;
using Homeworks.Module2HW3.Helpers;

namespace Homeworks.Module2HW3;

public class Program
{
    public static void Main()
   {
       Sweet[] childrensGift = new Sweet[]
       {
           new Candy("MintCandy", 50, "Mint"),
           new Candy("Lollipop", 30, "Strawberry"),
           new Candy("Gummy Bears", 45, "Fruit"),
           new Chocolate("Corona", 40, "White"),
           new Chocolate("Corona", 40, "Dark"),
           new ChocolateCandy("Roshen", 120, "Dark", "Fruit"),
       };

       PrintGiftsTotalWeight(childrensGift);

       PrintSortedGift(childrensGift);

       SearchSweetsByName(childrensGift);
   }

    private static void SearchSweetsByName(Sweet[] sweets)
    {
        Console.WriteLine("Search candy by it's name: ");

        var name = Console.ReadLine();

        foreach (var sweet in sweets)
        {
            if (sweet.Name == name)
            {
                Console.WriteLine($"Founded sweet: Name: {sweet.Name}, Weight: {sweet.Weight}");
            }
        }

        Console.WriteLine("Sweet with that name doesn't exist.");
    }

    private static void PrintSortedGift(Sweet[] gift)
    {
        Sweet[] giftCopy = (Sweet[])gift.Clone();

        Array.Sort(giftCopy, new SortGiftByName());

        Console.WriteLine("Sorted gift:");
        foreach (var sweet in giftCopy)
        {
            Console.WriteLine($"Name: {sweet.Name}, Weight: {sweet.Weight}");
        }
    }

    private static void PrintGiftsTotalWeight(Sweet[] gift)
    {
        double totalWeight = gift.Sum(sweet => sweet.Weight);
        Console.WriteLine($"Total weight of the children's gift: {totalWeight} grams");
    }
}