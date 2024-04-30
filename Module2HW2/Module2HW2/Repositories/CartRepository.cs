namespace Homeworks.Module2HW2.Repositories;

public class CartRepository
{
    private Cart[] _data;

    public CartRepository()
    {
        _data = new Cart[0];
    }

    public void Save(Cart cart)
    {
        for (int i = 0; i < _data.Length; i++)
        {
            if (_data[i].Id == cart.Id)
            {
                _data[i] = cart;
                break;
            }
        }

        ResizeData(cart, cart.Id);
    }

    public Cart Get(int cartId)
    {
        for (int i = 0; i < _data.Length; i++)
        {
            if (_data[i].Id == cartId)
            {
                return _data[i];
            }
        }

        ResizeData(null, cartId);

        return _data[_data.Length - 1];
    }

    private void ResizeData(Cart cart, int id)
    {
        var products = new Cart[_data.Length + 1];
        Array.Copy(_data, products, _data.Length);
        if (cart == null)
        {
            products[products.Length - 1] = new Cart() { Id = id, Products = new Product[0] };
        }
        else
        {
            products[_data.Length - 1] = cart;
        }

        _data = products;
    }
}