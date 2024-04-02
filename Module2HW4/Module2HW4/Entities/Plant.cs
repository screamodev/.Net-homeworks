namespace Module2HW4.Entities;

public class Plant
{
    protected Plant(string name)
    {
        Name = name;
    }

    public string Name { get; }
}