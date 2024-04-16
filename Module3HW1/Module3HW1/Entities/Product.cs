namespace Module3HW1.Entities;

public class Product
{
    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; set; }
    public int Price { get; set; }
}