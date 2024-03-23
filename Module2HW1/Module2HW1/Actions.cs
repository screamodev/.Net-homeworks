namespace Homeworks.Module2HW1;

public class Actions
{
    private readonly Logger _logger = Logger.LoggerInstance;

    public Result SendSomeRequest()
    {
        _logger.Log(LogType.Info, "Start method: SendSomeRequest");
        return new Result() { Status = true };
    }

    public Result SortSomeData()
    {
        _logger.Log(LogType.Warning, "Skipped logic in method: SortSomeData");
        return new Result() { Status = true };
    }

    public Result DeleteAnItem()
    {
        return new Result() { Status = false, ErrorMessage = "I broke a logic" };
    }
}