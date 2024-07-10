namespace Catalog.Host;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args);
    }

    private static void CreateHostBuilder(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.MapControllers();

        app.Run();
    }
}

