using System.Collections;
using Homeworks.Module2HW3.Entities;

namespace Homeworks.Module2HW3.Helpers;

public class SortGiftByName : IComparer
{
    int IComparer.Compare(object x, object y)
    {
        Sweet obj1 = (Sweet)x;
        Sweet obj2 = (Sweet)y;

        return string.Compare(obj1.Name, obj2.Name);
    }
}