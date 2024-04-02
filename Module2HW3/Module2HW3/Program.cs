using Homeworks.Module2HW3.Entities;
using Homeworks.Module2HW3.Helpers;

namespace Homeworks.Module2HW3;

public class Program
{
    public static void Main()
   {
       Sweet[] sweets = new Sweet[]
       {
           new Candy("MintCandy", 50, "Mint"),
           new Candy("Lollipop", 30, "Strawberry"),
           new Candy("Gummy Bears", 45, "Fruit"),
           new Chocolate("Corona", 40, "White"),
           new Chocolate("Corona", 40, "Dark"),
           new ChocolateCandy("Roshen", 120, "Dark", "Fruit"),
       };

       Gift gift = new Gift(sweets);

       gift.PrintGiftsTotalWeight();

       var sortedGift = gift.SortGift();

       Console.WriteLine($"Sorted gift: ");
       gift.PrintGift(sortedGift);

       var foundedSweets = gift.SearchSweetsByName();

       if (foundedSweets != null)
       {
           Console.WriteLine($"Founded sweets: ");
           gift.PrintGift(foundedSweets);
       }
       else
       {
           Console.WriteLine("Sweet with that name doesn't exist.");
       }
   }
}