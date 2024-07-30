using Basket.Host.Services.Interfaces;

namespace Basket.Host.Services;

public class BasketService : IBasketService
{
    public void GetAllAsync()
    {
        Console.WriteLine("TestMessage");
    }

    public void GetOneAsync(string userId)
    {
        Console.WriteLine($"userId: {userId}");
    }

    public void AddAsync()
    {
    }
}