using System.Text;

namespace module3HW7;

public class Logger
{
    private int _logCount;
    private List<LogEntity> _collection;
    private object _lock = new object();

    public Logger(int logCount)
    {
        _logCount = logCount;
        _collection = new List<LogEntity>();
    }

    public event Action<string> OnBackup;

    public async Task Log(DateTime date, string message)
    {
        lock (_lock)
        {
            _collection.Add(new LogEntity() { Date = date, Message = message });
            if (_collection.Count == _logCount)
            {
                var fileName = "Backup/" + DateTime.Now.ToShortTimeString() + ".txt";

                if (!Directory.Exists("Backup"))
                {
                    Directory.CreateDirectory("Backup");
                }

                File.WriteAllText(fileName, Stringify());
                _collection.Clear();

                if (OnBackup != null)
                {
                    OnBackup(fileName);
                }
            }
        }
    }

    private string Stringify()
    {
        var result = new StringBuilder();

        foreach (var item in _collection)
        {
            result.AppendLine(item.Date.ToShortTimeString() + ": " + item.Message);
        }

        return result.ToString();
    }
}