namespace Homeworks.Module2HW1;

public sealed class Logger
{
    private const int MaxLogsAmount = 100;

    private static readonly Logger Instance = new ();

    public static Logger LoggerInstance => Instance;

    private string[] Logs { get; } = new string[MaxLogsAmount];
    private int LogsCurrentIndex { get; set; }

    public void Log(string logType, string logMessage)
    {
        if (Logs.Length == LogsCurrentIndex)
        {
            Console.WriteLine("Too much logs.");
            return;
        }

        string log = $"{DateTime.Now}: {logType}: {logMessage}\n";
        LogsCurrentIndex++;
        Logs[LogsCurrentIndex - 1] = log;
    }

    public void ShowLogs()
    {
        string result = string.Concat(Logs.Select(x => x));
        Console.WriteLine(result);
    }

    public void SaveLogs()
    {
        string result = string.Concat(Logs.Select(x => x));
        File.WriteAllText("log.txt", result);
    }
}