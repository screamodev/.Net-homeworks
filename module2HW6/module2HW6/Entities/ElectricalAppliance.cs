using module2HW6.Config.Comparers;
using Module2HW6.Entities.Interfaces;

namespace Module2HW6.Entities;

public class ElectricalAppliance : IProduct
{
    protected ElectricalAppliance(string name, double powerConsumption)
    {
        Name = name;
        PowerConsumption = powerConsumption;
    }

    public string Name { get; }
    public double PowerConsumption { get; }

    public virtual double Price { get; set; }

    public virtual string Brand { get; set; }
    protected bool IsPluggedIn { get; set; }

    public virtual void PlugIn()
    {
        IsPluggedIn = true;

        Console.WriteLine($"Electrical appliance has been plugged in.");
    }

    public static double CalculateConsumption(ElectricalAppliance[] devices)
    {
        double totalConsumption = 0;

        foreach (var device in devices)
        {
            if (device.IsPluggedIn)
            {
                totalConsumption += device.PowerConsumption;
            }
        }

        return totalConsumption;
    }

    public static ElectricalAppliance[] SortAppliancesByConsumption(ElectricalAppliance[] devices)
    {
        ElectricalAppliance[] devicesCopy = new ElectricalAppliance[devices.Length];

        Array.Copy(devices, devicesCopy, devices.Length);

        Array.Sort(devices, new SortAppliancesByConsumptionComparer());

        return devicesCopy;
    }

    public static ElectricalAppliance[] FindByPrice(ElectricalAppliance[] devices, double minPrice, double maxPrice)
    {
        ElectricalAppliance[] devicesCopy = new ElectricalAppliance[devices.Length];

        int foundedDevicesCounter = 0;

        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].Price >= minPrice && devices[i].Price <= maxPrice)
            {
                devicesCopy[foundedDevicesCounter] = devices[i];
                foundedDevicesCounter++;
            }
        }

        Array.Resize(ref devicesCopy, foundedDevicesCounter);

        return devicesCopy;
    }
}