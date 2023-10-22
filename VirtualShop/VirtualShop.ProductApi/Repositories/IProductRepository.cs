using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Repositories;

/// <summary>
/// Interface que indica a implementação das ações do CRUD de product
/// </summary>
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(int id);
    Task<Product> Create(Product product);
    Task<Product> Update(Product product);
    Task<Product> Delete(int id);
}
