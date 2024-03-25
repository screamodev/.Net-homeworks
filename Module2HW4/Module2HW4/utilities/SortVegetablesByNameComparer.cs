using System.Collections;

namespace Module2HW4.utilities;

public class SortVegetablesByNameComparer : IComparer
{
    int IComparer.Compare(object x, object y)
    {
        Vegetable obj1 = (Vegetable)x;
        Vegetable obj2 = (Vegetable)y;

        return string.Compare(obj1.Name, obj2.Name);
    }
}