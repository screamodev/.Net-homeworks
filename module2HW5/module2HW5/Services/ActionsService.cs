using Module2HW5.BusinessExceptions;

namespace Module2HW5.Services;

public class ActionsService
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