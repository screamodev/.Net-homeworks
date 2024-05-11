namespace module3HW7;

public class App
{
    private Logger _logger;

    public App(int logCount)
    {
        _logger = new Logger(logCount);
        _logger.OnBackup += Print;
    }

    public void Run()
    {
        var task1 = Task.Run(() =>
        {
            for (int i = 0; i < 50; i++)
            {
                _logger.Log(DateTime.Now, "Message from the loop 1, with id: " + i);
            }
        });

        var task2 = Task.Run(() =>
        {
            for (int i = 0; i < 50; i++)
            {
                _logger.Log(DateTime.Now, "Message from the loop 2, with id: " + i);
            }
        });

        Task.WaitAll(new Task[] { task1, task2 });
    }

    private void Print(string fileName)
    {
        Console.WriteLine("File was backed-up: " + fileName);
    }
}