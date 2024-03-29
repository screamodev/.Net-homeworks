namespace Homeworks.Module2HW1;

public class Starter
{
    private const int MaxIterationsAmount = 100;

    private readonly Logger _logger = Logger.LoggerInstance;

    public void Run()
    {
        Actions actions = new Actions();
        var loopCounter = 0;

        while (loopCounter < MaxIterationsAmount)
        {
            loopCounter++;

            var randomNumber = new Random().Next(1, 4);

            switch (randomNumber)
            {
                case 1:
                    try
                    {
                        actions.SendSomeRequest();
                    }
                    catch (Exception error)
                    {
                        _logger.Log(LogType.Info, $"Action failed by a reason: {error.Message}");
                    }
                    break;
                case 2:
                    try
                    {
                        actions.SortSomeData();
                    }
                    catch (Exception error)
                    {
                        _logger.Log(LogType.Warning, $"Action got this custom Exception : {error.Message}");
                    }
                    break;
                case 3:
                    try
                    {
                        actions.DeleteAnItem();
                    }
                    catch (Exception error)
                    {
                        _logger.Log(LogType.Error, $"Action failed by a reason: {error.Message}");
                    }
                    break;
            }
        }

        _logger.ShowLogs();

        _logger.SaveLogs();
    }
}