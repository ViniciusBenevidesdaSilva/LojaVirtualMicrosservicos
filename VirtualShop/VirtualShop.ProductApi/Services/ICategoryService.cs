using VirtualShop.ProductApi.DTOs;

namespace VirtualShop.ProductApi.Services;

/// <summary>
/// Interface com o CRUD a ser implementado pelo Serviço de Categoria
/// </summary>
public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
    Task<CategoryDTO> GetCategoryById(int id);

    Task AddCategory(CategoryDTO categoryDTO);
    Task UpdateCategory(CategoryDTO categoryDTO);
    Task RemoveCategory(int id);
}
