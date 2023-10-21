using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    // TODO - Usar Fluent API para sobrescrever as convenções do Entity Framework Core

}
