using Homeworks.Module2HW2.Repositories;

namespace Homeworks.Module2HW2.Services;

public class CartService
{
    private readonly CartRepository _repository;

    public CartService(CartRepository cartRepository)
    {
        _repository = cartRepository;
    }

    public Cart Add(int cartId, Product product)
    {
        var cart = _repository.Get(cartId);

        var products = new Product[cart.Products.Length + 1];

        Array.Copy(cart.Products, products, cart.Products.Length);
        products[products.Length - 1] = product;
        cart.Products = products;

        cart.TotalPrice += product.Cost;

        _repository.Save(cart);
        return cart;
    }
}