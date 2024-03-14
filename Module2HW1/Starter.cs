namespace Homeworks.Module2HW1;

public class Starter
{
    private const int MaxIterationsAmount = 100;

    private readonly Logger _logger = Logger.LoggerInstance;

    private int LoopCounter { get; set; }

    public void Run()
    {
        Actions actions = new Actions();

        while (LoopCounter < MaxIterationsAmount)
        {
            LoopCounter++;

            var randomNumber = new Random().Next(1, 4);

            switch (randomNumber)
            {
                case 1:
                    Result requestResult = actions.SendSomeRequest();
                    if (requestResult.Status == false)
                    {
                        _logger.Log("Error", $"Action failed by a reason: {requestResult.ErrorMessage}");
                    }

                    break;
                case 2:
                    Result sortResult = actions.SortSomeData();
                    if (sortResult.Status == false)
                    {
                        _logger.Log("Error", $"Action failed by a reason: {sortResult.ErrorMessage}");
                    }

                    break;
                case 3:
                    Result deleteResult = actions.DeleteAnItem();
                    if (deleteResult.Status == false)
                    {
                       _logger.Log("Error", $"Action failed by a reason: {deleteResult.ErrorMessage}");
                    }

                    break;
            }
        }

        _logger.ShowLogs();

        _logger.SaveLogs();
    }
}