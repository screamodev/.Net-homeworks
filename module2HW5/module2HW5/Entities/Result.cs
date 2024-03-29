namespace Homeworks.Module2HW1;

public class Result
{

    public Result(DateTime time, LogType logType, string errorMessage)
    {
        Time = time;
        LogType = logType;
        ErrorMessage = errorMessage;
    }
    
    public DateTime Time { get; set; }
    public LogType LogType { get; set; }
    public string ErrorMessage { get; set; }
}