namespace Homeworks.Module2HW2;

public class Product
{
    public Product(int id, string name, int cost)
    {
        Id = id;
        Name = name;
        Cost = cost;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
}