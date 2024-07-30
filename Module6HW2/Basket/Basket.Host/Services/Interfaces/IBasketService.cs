namespace Basket.Host.Services.Interfaces;

public interface IBasketService
{
   void GetAllAsync();

   void GetOneAsync(string userId);

   void AddAsync();
}