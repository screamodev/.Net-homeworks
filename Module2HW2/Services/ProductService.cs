using Homeworks.Module2HW2.Repositories;

namespace Homeworks.Module2HW2.Services;

public class ProductService
{
  private ProductRepository _repository;

  public ProductService(ProductRepository repository)
  {
    _repository = repository;
  }

  public Product[] GetAll()
  {
    return _repository.GetAll();
  }

  public Product GetProductById(int id)
  {
    return _repository.GetById(id);
  }
}