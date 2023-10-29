namespace VirtualShop.ProductApi.Models;

/// <summary>
/// Model da Categoria que espelha a tabela do banco
/// Usada pela migration para criação da tabela
/// Responsável por comunicar Service <-> Repository
/// </summary>
public class Category
{
    public int CategoryID { get; set; }
    public string? Name { get; set; }

    public ICollection<Product>? Products { get; set; }
}
