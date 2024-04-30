using System.Collections;
using Module2HW6.Entities;

namespace module2HW6.Config.Comparers;

public class SortAppliancesByConsumptionComparer : IComparer
{
    int IComparer.Compare(object x, object y)
    {
        ElectricalAppliance obj1 = (ElectricalAppliance)x;
        ElectricalAppliance obj2 = (ElectricalAppliance)y;

        if (obj1.PowerConsumption > obj2.PowerConsumption)
        {
            return 1;
        }

        if (obj1.PowerConsumption < obj2.PowerConsumption)
        {
            return -1;
        }

        return 0;
    }
}