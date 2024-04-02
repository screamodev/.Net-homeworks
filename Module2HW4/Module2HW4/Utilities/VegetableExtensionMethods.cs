using Module2HW4.Entities;

namespace Module2HW4.Utilities;

public static class VegetableExtensionMethods
{
    public static RootVegetable[] FindRootVegetables(this Vegetable veg, Salad salad)
    {
        RootVegetable[] rootVegetables = new RootVegetable[salad.Vegetables.Length];
        int rootVegetablesCounter = 0;

        foreach (var vegetable in salad.Vegetables)
        {
            if (vegetable is RootVegetable rootVegetable && rootVegetable.IsRoot)
            {
                rootVegetables[rootVegetablesCounter++] = rootVegetable;
            }
        }

        Array.Resize(ref rootVegetables, rootVegetablesCounter);

        return rootVegetables;
    }
}