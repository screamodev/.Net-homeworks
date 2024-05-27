namespace Module3HW6;

public class MessageBox
{
    public event Action<State> OnWindowClose;
    
    public async Task Open()
    {
        Console.WriteLine("Window is open");
        await Task.Delay(3000);
        Console.WriteLine("Window was closed by the user");
        
        if (OnWindowClose != null)
        {
            OnWindowClose(GetRandomState());

        }
    }

    private State GetRandomState()
    {
        var random = new Random().Next(0, 2);

        if (random == 0)
        {
            return State.Ok;
        }
        
        return State.Cancel;

    }
}