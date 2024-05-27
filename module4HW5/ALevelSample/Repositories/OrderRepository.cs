using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Models;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int> AddOrderAsync(string user, List<OrderItem> items)
    {
        var result = await _dbContext.Orders.AddAsync(new OrderEntity()
        {
            UserId = user
        });

        await _dbContext.OrderItems.AddRangeAsync(items.Select(s => new OrderItemEntity()
        {
            Count = s.Count,
            OrderId = result.Entity.Id,
            ProductId = s.ProductId
        }));

        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<int> UpdateOrderAsync(int orderId, List<OrderItem> items)
    {
        var order = await _dbContext.Orders.FindAsync(orderId);

        if (order == null)
        {
            throw new Exception("Order not found");
        }

        _dbContext.OrderItems.UpdateRange(items.Select(s => new OrderItemEntity()
        {
            Count = s.Count,
            OrderId = order.Id,
            ProductId = s.ProductId
        }));

        await _dbContext.SaveChangesAsync();

        return order.Id;
    }

    public async Task<bool> DeleteOrderAsync(int orderId)
    {
        var order = await _dbContext.Orders.FindAsync(orderId);

        if (order == null)
        {
            throw new Exception("Order not found");
        }

        _dbContext.Remove(order);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<OrderEntity?> GetOrderAsync(int id)
    {
        return await _dbContext.Orders.Include(i => i.OrderItems).FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<OrderEntity>?> GetOrderByUserIdAsync(string id)
    {
        return await _dbContext.Orders.Include(i => i.OrderItems).Where(f => f.UserId == id).ToListAsync();
    }
}