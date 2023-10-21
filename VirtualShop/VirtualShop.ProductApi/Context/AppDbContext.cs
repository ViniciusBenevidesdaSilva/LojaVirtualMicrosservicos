using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    // Usar Fluent API para sobrescrever as convenções do Entity Framework Core
    protected override void OnModelCreating(ModelBuilder mb)
    {
        // Category
        CategoryAttributes(mb);

        // Product
        ProductAttributes(mb);


        // Relationships
        Relationships(mb);

        // Popular a tabela category
        CategoryHasData(mb);
    }

    private void CategoryAttributes(ModelBuilder mb)
    {
        mb.Entity<Category>().HasKey(c => c.CategoryID);
        mb.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
    }

    private void CategoryHasData(ModelBuilder mb)
    {
        mb.Entity<Category>()
            .HasData(
                new Category { CategoryID = 1, Name = "Material Escolar" },
                new Category { CategoryID = 2, Name = "Acessórios" }
            );
    }

    private void ProductAttributes(ModelBuilder mb)
    {
        mb.Entity<Product>()
           .Property(c => c.Name)
           .HasMaxLength(100)
           .IsRequired();
        mb.Entity<Product>()
            .Property(c => c.Description)
            .HasMaxLength(255)
            .IsRequired();
        mb.Entity<Product>()
            .Property(c => c.ImageURL)
            .HasMaxLength(255)
            .IsRequired();
        mb.Entity<Product>()
            .Property(c => c.Price)
            .HasPrecision(12, 2);
    }

    private void Relationships(ModelBuilder mb)
    {
        mb.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
    }


}
