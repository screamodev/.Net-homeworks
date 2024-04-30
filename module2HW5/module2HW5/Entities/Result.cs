namespace Module2HW5.Entities;

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