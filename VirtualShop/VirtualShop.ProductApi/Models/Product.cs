namespace VirtualShop.ProductApi.Models;

/// <summary>
/// Model do Produto que espelha a tabela do banco
/// Usada pela migration para criação da tabela
/// Responsável por comunicar Service <-> Repository
/// </summary>
public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public long Stock { get; set; }
    public string? ImageURL { get; set; }
    public int CategoryID { get; set; }

    // Propriedades de navegação, não definidas quando o banco é gerado
    public Category? Category { get; set; }
}
