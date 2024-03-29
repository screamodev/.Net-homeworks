using System.Collections;

namespace Module2HW4.utilities;

public class SortFileByDateComparer : IComparer
{
    int IComparer.Compare(object x, object y)
    {
        FileInfo obj1 = (FileInfo)x;
        FileInfo obj2 = (FileInfo)y;

        return string.Compare(obj1.CreationTime.ToString(), obj2.CreationTime.ToString());
    }
}