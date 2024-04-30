using Module2HW6.Entities;

namespace Module2HW6;

public class Program
{
  public static void Main()
  {
    ElectricalAppliance[] electricalAppliances = new ElectricalAppliance[]
    {
      new HairDryer("QWE40RTY", 1000, 200, "Xiaomi"),
      new Television("70PUS8518", 180.5, 399.50, "Philips"),
      new Television("50PUS8519", 150, 320, "Philips"),
      new SmartTelevision("150GFS8528", 320.1, 1099, "LG", new string[] { "Voice Control" }),
      new SmartTelevision("130LUS8538", 290, 1600, "LG", new string[] { "Streaming apps", "Voice Control" }),
      new Oled77C4()
    };

    foreach (var device in electricalAppliances)
    {
      if (device.PowerConsumption <= 300)
      {
        device.PlugIn();
      }
    }

    double totalConsumption = ElectricalAppliance.CalculateConsumption(electricalAppliances);
    Console.WriteLine($"\nTotal consumption of all plugged in devices: {totalConsumption}");

    ElectricalAppliance[] sortedElectricalAppliances =
      ElectricalAppliance.SortAppliancesByConsumption(electricalAppliances);

    Console.WriteLine("\nDevices sorted by consumption:");
    foreach (var device in sortedElectricalAppliances)
    {
      Console.WriteLine($"Name: {device.Name}; Consumption: {device.PowerConsumption};");
    }

    int userInputMinPrice;
    int userInputMaxPrice;

    Console.WriteLine("Search device in specific price range: ");
    Console.WriteLine("Enter min price: ");
    if (!int.TryParse(Console.ReadLine(), out userInputMinPrice))
    {
      Console.WriteLine($"Invalid user input.");
      return;
    }

    Console.WriteLine("Enter max price: ");
    if (!int.TryParse(Console.ReadLine(), out userInputMaxPrice))
    {
      Console.WriteLine($"Invalid user input.");
      return;
    }

    ElectricalAppliance[] foundedDevices = ElectricalAppliance.FindByPrice(electricalAppliances, userInputMinPrice, userInputMaxPrice);

    Console.WriteLine("\nDevices in specific price range:");
    if (foundedDevices.Length != 0)
    {
      foreach (var device in foundedDevices)
      {
        Console.WriteLine($"Name: {device.Name}; Price: {device.Price};");
      }
    }
    else
    {
      Console.WriteLine("Devices not found.");
    }
  }
}

// Determine the hierarchy of electrical appliances. +
// Plug some in. +
// Calculate the power consumption. +
// Sort the appliances in the apartment based on one of the parameters. +
// Find a device in the apartment that matches the specified range of parameters. +