using Module3HW6;

public class Program
{
    public static async Task Main()
    {
        var messageBox = new MessageBox();
        messageBox.OnWindowClose += HandleOnClose;

        await messageBox.Open();

        Console.ReadLine();
    }

    private static void HandleOnClose(State state)
    {
        switch (state)
        {
            case State.Ok:
                Console.WriteLine("The operation has been confirmed");
                break;
            case State.Cancel:
                Console.WriteLine("The operation was rejected");
                break;
        }
    }
}