using System.Diagnostics;
using Module2HW4.utilities;

namespace Module2HW4.entities;

public class Salad : Vegetable
{
    public Salad(string name, double calories, double weight, Vegetable[] vegetables) : base(name, calories, weight)
    {
        Vegetables = vegetables;
    }

    public Vegetable[] Vegetables { get; set; }

    public static double CalculateCalories(Vegetable[] vegetables)
    {
        double calories = 0;

        foreach (var vegetable in vegetables)
        {
            calories += vegetable.Calories;
        }

        return calories;
    }

    public static double CalculateWeight(Vegetable[] vegetables)
    {
        double weight = 0;

        foreach (var vegetable in vegetables)
        {
            weight += vegetable.Weight;
        }

        return weight;
    }

    public void PrintSaladIngredients()
    {
        foreach (var vegetable in Vegetables)
        {
            Console.WriteLine($"Name: {vegetable.Name}");
        }
    }

    public void SortVegetablesByName()
    {
        Array.Sort(Vegetables, new SortVegetablesByNameComparer());
    }
}