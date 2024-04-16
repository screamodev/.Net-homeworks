namespace Module2HW6.Entities;

public class Oled77C4 : SmartTelevision
{
    private static readonly string[] TvFeatures = new string[] { "Streaming apps", "Voice Control" };

    public Oled77C4()
        : base("Oled77C4", 194, 3299.99, "LG", TvFeatures)
    {
    }

    public void TurnOnStreamingAppFeature()
    {
        const string streamingAppsFeature = "Streaming apps";

        foreach (var feature in SmartFeatures)
        {
            if (feature == streamingAppsFeature)
            {
                Console.WriteLine($"{streamingAppsFeature} turned on.");
                return;
            }
        }

        Console.WriteLine("That feature isn't available.");
    }
}