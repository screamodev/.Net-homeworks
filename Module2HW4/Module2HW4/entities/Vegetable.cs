public class Vegetable : Plant
{
    public Vegetable(string name, double calories, double weight) : base(name)
    {
        Calories = calories;
        Weight = weight;
    }

    public double Calories { get; set; }
    public double Weight { get; set; }
}