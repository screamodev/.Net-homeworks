namespace module3HW3;

public delegate int MultiplyCallBack(int x, int y);

public delegate bool ResultCallBack(int x);
public class SecondClass
{
    private int _result;
    
    public ResultCallBack Calc(MultiplyCallBack multiply, int x, int y)
    {
        _result = multiply(x, y);
        return Result;
    }

    private bool Result(int x)
    {
        return _result % x == 0;
    }
}