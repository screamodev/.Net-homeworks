namespace Module3HW4;

public class Task1
{
    public event Action<int> OnCalculate;

    public void Print(int i)
    {
        Console.WriteLine("Result: " + i);
    }

    public void AnotherPrint(int i)
    {
        Console.WriteLine("Another result: " + i);
    }

    public void Run(Func<int, int, int> calculation, int x, int y)
    {
        try
        {
            calculation(x, y);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public int Calculate(int x, int y)
    {
        var result = x + y;

        if (x == 0)
        {
            throw new Exception("x can't be null");
        }

        if (OnCalculate != null)
        {
            OnCalculate(result);
        }

        return result;
    }
}