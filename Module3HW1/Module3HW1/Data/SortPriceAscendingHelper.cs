using System.Collections;
using Module3HW1.Entities;

namespace Module3HW1.Data;

public class SortPriceAscendingHelper : IComparer
{
    int IComparer.Compare(object a, object b)
    {
        Product p1 = (Product)a;
        Product p2 = (Product)b;
        if (p1.Price > p2.Price)
        {
            return 1;
        }

        if (p1.Price < p2.Price)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}