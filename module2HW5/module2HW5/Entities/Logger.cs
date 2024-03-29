using Homeworks.Module2HW1.Repositories;
using Newtonsoft.Json;

namespace Homeworks.Module2HW1;

public sealed class Logger
{
    private static readonly Logger Instance = new ();

    private LinkedList _logs = new LinkedList();

    static Logger()
    {
    }

    private Logger()
    {
    }

    public static Logger LoggerInstance => Instance;

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