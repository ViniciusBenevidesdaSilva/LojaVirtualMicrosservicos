using VirtualShop.ProductApi.DTOs;

namespace VirtualShop.ProductApi.Services;

/// <summary>
/// Interface com o CRUD a ser implementado pelo Serviço de Produto
/// </summary>
public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetProductById(int id);

    Task AddProduct(ProductDTO productDTO);
    Task UpdateProduct(ProductDTO productDTO);
    Task RemoveProduct(int id);
}
