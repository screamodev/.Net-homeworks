namespace Homeworks.Module2HW2.Repositories;

public class OrderRepository
{
    private Order[] _data;

    public OrderRepository()
    {
        _data = new Order[0];
    }

    public Order Save(Order order)
    {
        var id = _data.Length + 1;
        order.Id = id;

        var products = new Order[_data.Length + 1];
        Array.Copy(_data, products, _data.Length);
        products[products.Length - 1] = order;
        _data = products;
        return order;
    }
}