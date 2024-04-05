using Module2HW5.Data;
using Module2HW5.Entities;
using Module2HW5.Repositories;
using Module2HW5.Services;
using Newtonsoft.Json;

public sealed class LoggerService
{
    private static readonly LoggerService Instance = new ();

    private LinkedList _logs = new LinkedList();

    static LoggerService()
    {
    }

    private LoggerService()
    {
    }

    public static LoggerService LoggerServiceInstance => Instance;

    public void Log(LogType logType, string logMessage)
    {
        Result result = new Result(DateTime.Now, logType, logMessage);
        
        _logs.InsertLast(_logs, result);
    }

    public void ShowLogs()
    {
        var logs = _logs.GetAllNodes(_logs);
        string jsonLogs = JsonConvert.SerializeObject(logs, Formatting.Indented);

        Console.WriteLine(jsonLogs);
    }

    public void SaveLogs()
    {
        var logs = _logs.GetAllNodes(_logs);
        FileService fileService = new FileService(new FileRepository());

        string jsonLogs = JsonConvert.SerializeObject(logs, Formatting.Indented);
        fileService.WriteFile("logs", jsonLogs);

    }
}