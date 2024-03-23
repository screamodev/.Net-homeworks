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
        string log = $"{DateTime.Now}: {logType}: {logMessage}\n";
        _logs.InsertLast(_logs, log);
    }

    public void ShowLogs()
    {
        var result = _logs.GetAllNodes(_logs);

        Console.WriteLine(result);
    }

    public void SaveLogs()
    {
        var result = _logs.GetAllNodes(_logs);

        Console.WriteLine(result);

        File.WriteAllText("log.txt", result);
    }
}