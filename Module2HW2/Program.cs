using Homeworks.Module2HW2.Repositories;
using Homeworks.Module2HW2.Services;

namespace Homeworks.Module2HW2;

public class Program
{
   public static void Main()
    {
        var productService = new ProductService(new ProductRepository());
        var products = productService.GetAll();
        PrintProducts(products);

        var cartService = new CartService(new CartRepository());

        ChooseProduct(productService, cartService, 1);
    }

   public static void PrintProducts(Product[] products)
   {
       foreach (var product in products)
       {
           Console.WriteLine($"Id: {product.Id} | Name: {product.Name} | Price: {product.Cost} uah");
       }
   }

   public static void ChooseProduct(ProductService productService, CartService cartService, int cartId)
   {
       bool isFinished = false;
       while (!isFinished)
       {
           Console.WriteLine("Enter product id: ");
           int productId;

           if (!int.TryParse(Console.ReadLine(), out productId))
           {
             Console.WriteLine($"Invalid user input.");
             return;
           }

           Product product = productService.GetProductById(productId);

           Cart cart = cartService.Add(cartId, product);
           Console.WriteLine("Product was successfully added to the cart!\nIf you want to make order press: '0'\nIf you want to continue press: '1'");

           int userChoice;

           if (!int.TryParse(Console.ReadLine(), out userChoice))
           {
               Console.WriteLine($"Invalid user input.");
               return;
           }

           if (userChoice == 0)
           {
               isFinished = true;
           }

           if (isFinished)
           {
               var orderService = new OrderService(new OrderRepository());
               var order = orderService.Create(cart);
               PrintOrder(order);
           }
       }
   }

   public static void PrintOrder(Order order)
   {
       Console.WriteLine("Your order is: ");

       foreach (var product in order.Products)
       {
          Console.WriteLine($"{product.Name}: {product.Cost} uah");
       }

       Console.WriteLine($"Total price: {order.TotalPrice} uah");
   }
}