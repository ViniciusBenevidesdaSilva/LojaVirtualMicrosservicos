using AutoMapper;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Models;
using VirtualShop.ProductApi.Repositories;

namespace VirtualShop.ProductApi.Services;

/// <summary>
/// Classe que implementa o CRUD definido pela ICategoryService, utilizando os Repositories e Mapper para comunicar DTO para Entity
/// </summary>
public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categoriesEntity = await _categoryRepository.GetAll();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
    {
        var categoriesEntity = await _categoryRepository.GetCategoriesProducts();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }

    public async Task<CategoryDTO> GetCategoryById(int id)
    {
        var categoryEntity = await _categoryRepository.GetById(id);
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }

    public async Task AddCategory(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.Create(categoryEntity);

        categoryDTO.CategoryID = categoryEntity.CategoryID;
    }

    public async Task UpdateCategory(CategoryDTO categoryDTO)
    {
        var categoryEntity = _mapper.Map<Category>(categoryDTO);
        await _categoryRepository.Update(categoryEntity);
    }

    public async Task RemoveCategory(int id)
    {
        var categoryEntity = _categoryRepository.GetById(id).Result;
        await _categoryRepository.Delete(categoryEntity.CategoryID);
    }
}
