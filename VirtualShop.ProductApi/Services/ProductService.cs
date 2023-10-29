using AutoMapper;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Models;
using VirtualShop.ProductApi.Repositories;

namespace VirtualShop.ProductApi.Services;

/// <summary>
/// Classe que implementa o CRUD definido pela IProductService, utilizando os Repositories e Mapper para comunicar DTO para Entity
/// </summary>
public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsEntity = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
    }

    public async Task<ProductDTO> GetProductById(int id)
    {
        var productsEntity = await _productRepository.GetById(id);
        return _mapper.Map<ProductDTO>(productsEntity);
    }

    public async Task AddProduct(ProductDTO productDTO)
    {
        var productsEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.Create(productsEntity);

        productDTO.Id = productsEntity.Id;
    }

    public async Task UpdateProduct(ProductDTO productDTO)
    {
        var productsEntity = _mapper.Map<Product>(productDTO);
        await _productRepository.Update(productsEntity);
    }

    public async Task RemoveProduct(int id)
    {
        var productsEntity = _productRepository.GetById(id).Result;
        await _productRepository.Delete(productsEntity.Id);
    }
}
