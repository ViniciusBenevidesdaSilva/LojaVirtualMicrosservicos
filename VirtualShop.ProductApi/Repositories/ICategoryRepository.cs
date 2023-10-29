using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Repositories;

/// <summary>
/// Interface que indica a implementação das ações do CRUD de categoria
/// </summary>
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAll();
    Task<IEnumerable<Category>> GetCategoriesProducts();
    Task<Category> GetById(int id);
    Task<Category> Create(Category category);
    Task<Category> Update(Category category);
    Task<Category> Delete(int id);
}
