using Microsoft.Extensions.Configuration;

namespace module3HW7;

public class Program
{
    public static void Main()
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var section = config.GetSection("LoggingCount");
        var n = int.Parse(section.Value);

        var app = new App(n);
        app.Run();
    }
}