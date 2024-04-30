namespace Homeworks.Module2HW2.Repositories;

public class ProductRepository
{
    private Product[] _products = new Product[]
   {
       new Product(1, "Banana", 30),
       new Product(2, "Apple", 15),
       new Product(3, "Carrot", 5),
       new Product(4, "Onion", 5),
       new Product(5, "Garlic", 25),
   };

    public Product[] GetAll()
    {
        return _products;
    }

    public Product GetById(int id)
    {
        foreach (var product in _products)
        {
            if (product.Id == id)
            {
                return product;
            }
        }

        return null;
    }
}