using Homeworks.Module2HW3.Helpers;

namespace Homeworks.Module2HW3.Entities;

public class Gift
{
    public Gift(Sweet[] sweet)
    {
        Sweets = sweet;
    }

    private Sweet[] Sweets { get; set; }

    public void PrintGiftsTotalWeight()
    {
        double totalWeight = Sweets.Sum(sweet => sweet.Weight);
        Console.WriteLine($"Total weight of the children's gift: {totalWeight} grams");
    }

    public Sweet[] SortGift()
    {
        Sweet[] gift = (Sweet[])Sweets.Clone();

        Array.Sort(gift, new SortGiftByName());

        return gift;
    }

    public void PrintGift(Sweet[] gift)
    {
        foreach (var sweet in gift)
        {
            Console.WriteLine($"Name: {sweet.Name}, Weight: {sweet.Weight}");
        }
    }

    public Sweet[] SearchSweetsByName()
    {
        Sweet[] sweets = new Sweet[Sweets.Length];

        Console.WriteLine("Search sweet by it's name: ");
        var name = Console.ReadLine();

        int counter = 0;

        for (int i = 0; i < Sweets.Length; i++)
        {
            if (Sweets[i].Name == name)
            {
                sweets[counter] = Sweets[i];
                counter++;
            }
        }

        Array.Resize(ref sweets, counter);

        if (sweets.Length != 0)
        {
            return sweets;
        }

        return null;
    }
}