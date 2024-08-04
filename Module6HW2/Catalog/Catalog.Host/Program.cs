using Catalog.Host.Configurations;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Filters;
using Infrastructure.Extensions;
using Infrastructure.RateLimit.Configurations;
using Infrastructure.RateLimit.Middlewares;
using Infrastructure.RateLimit.Services;
using Infrastructure.RateLimit.Services.Interfaces;
using Infrastructure.Redis.Configurations;
using Infrastructure.Redis.Services;
using Infrastructure.Redis.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var configuration = GetConfiguration();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
    {
        options.Filters.Add(typeof(HttpGlobalExceptionFilter));
    })
    .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

builder.Services.Configure<CatalogConfig>(configuration);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "eShop- Catalog HTTP API",
        Version = "v1",
        Description = "The Catalog Service HTTP API"
    });

    var authority = configuration["Authorization:Authority"];
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows()
        {
            Implicit = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri($"{authority}/connect/authorize"),
                TokenUrl = new Uri($"{authority}/connect/token"),
                Scopes = new Dictionary<string, string>()
                {
                    { "mvc", "website" },
                    { "catalog.catalogitem", "catalog.catalogitem" }
                }
            }
        }
    });

    options.OperationFilter<AuthorizeCheckOperationFilter>();
});

builder.AddConfiguration();

builder.Services.Configure<RedisConfig>(
    builder.Configuration.GetSection("Redis"));

builder.Services.Configure<RateLimitOptions>(options =>
{
    options.AllowedRequestsCount = 10;
    options.TimeLimit = TimeSpan.FromMinutes(1);
});

builder.Services.AddAuthorization(configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSingleton<IRateLimitService, RateLimitService>();

builder.Services.AddTransient<IJsonSerializer, JsonSerializer>();
builder.Services.AddTransient<IRedisCacheConnectionService, RedisCacheConnectionService>();
builder.Services.AddTransient<ICacheService, CacheService>();
builder.Services.AddTransient<ICatalogItemRepository, CatalogItemRepository>();
builder.Services.AddTransient<ICatalogItemService, CatalogItemService>();
builder.Services.AddTransient<ICatalogService, CatalogService>();
builder.Services.AddTransient<IRepository<CatalogBrand, CatalogBrandCreateDto, CatalogBrandUpdateDto>, Repository<CatalogBrand, CatalogBrandCreateDto, CatalogBrandUpdateDto>>();
builder.Services.AddTransient<ICatalogBrandService, CatalogBrandService>();
builder.Services.AddTransient<IRepository<CatalogType, CatalogTypeCreateDto, CatalogTypeUpdateDto>, Repository<CatalogType, CatalogTypeCreateDto, CatalogTypeUpdateDto>>();
builder.Services.AddTransient<ICatalogTypeService, CatalogTypeService>();

builder.Services.AddDbContextFactory<ApplicationDbContext>(opts => opts.UseNpgsql(configuration["ConnectionString"]));
builder.Services.AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "CorsPolicy",
        builder => builder
            .SetIsOriginAllowed((host) => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

app.UseSwagger()
    .UseSwaggerUI(setup =>
    {
        setup.SwaggerEndpoint($"{configuration["PathBase"]}/swagger/v1/swagger.json", "Catalog.API V1");
        setup.OAuthClientId("catalogswaggerui");
        setup.OAuthAppName("Catalog Swagger UI");
    });

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseRateLimit();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapControllers();
});

CreateDbIfNotExists(app);
app.Run();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}

void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            DbInitializer.Initialize(context).Wait();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}