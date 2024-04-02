using Module2HW5.Entities;

namespace Module2HW5.Services;

public class StarterService
{
    private const int MaxIterationsAmount = 100;

    private readonly LoggerService _logger = LoggerService.LoggerServiceInstance;

    private readonly ActionsService _actionsService = new ActionsService();

    public void Run()
    {
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
                        _actionsService.SendSomeRequest();
                    }
                    catch (Exception error)
                    {
                        _logger.Log(LogType.Info, $"Action failed by a reason: {error.Message}");
                    }
                    break;
                case 2:
                    try
                    {
                        _actionsService.SortSomeData();
                    }
                    catch (Exception error)
                    {
                        _logger.Log(LogType.Warning, $"Action got this custom Exception : {error.Message}");
                    }
                    break;
                case 3:
                    try
                    {
                        _actionsService.DeleteAnItem();
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