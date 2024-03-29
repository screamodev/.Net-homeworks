using Homeworks.Module2HW1.Exceptions;

namespace Homeworks.Module2HW1;

public class Actions
{
    public void SendSomeRequest()
    { }

    public void SortSomeData()
    {
        throw new SkippedLogicException("Skipped logic in method SortSomeData");
    }

    public void DeleteAnItem()
    {
        throw new Exception("I broke a logic");
    }
}