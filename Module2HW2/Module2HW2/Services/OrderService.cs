using Homeworks.Module2HW2.Repositories;

namespace Homeworks.Module2HW2.Services;

public class OrderService
{
    private readonly OrderRepository _repository;

    public OrderService(OrderRepository orderRepository)
    {
        _repository = orderRepository;
    }

    public Order Create(Cart cart)
    {
        var order = new Order()
        {
            Products = cart.Products,
            TotalPrice = cart.TotalPrice
        };

        return _repository.Save(order);
    }
}