using module3HW3;

class Program
{
    private static void Show(bool result)
    {
        Console.WriteLine(result);
    }
    
    public static void Main()
    {
        var secondClass = new SecondClass();
        
        var resultMethod = secondClass.Calc(FirstClass.Multiply, 10, 2);

        var show = new ShowCallBack(Show);

        show(resultMethod(2));
    } 
}