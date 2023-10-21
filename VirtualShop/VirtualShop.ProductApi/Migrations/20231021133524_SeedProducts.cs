using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualShop.ProductApi.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "Insert Into Products " +
                    "(Name, Price, Description, Stock, ImageURL, CategoryID) " +
                 "Values " +
                    "('Caderno', 7.55, 'Caderno', 10, 'caderno1.jpg', 1)"                );

            migrationBuilder.Sql(
                "Insert Into Products " +
                    "(Name, Price, Description, Stock, ImageURL, CategoryID) " +
                 "Values " +
                    "('Lápis', 3.45, 'Lápis Preto', 20, 'lapis1.jpg', 1)"                );

            migrationBuilder.Sql(
                "Insert Into Products " +
                    "(Name, Price, Description, Stock, ImageURL, CategoryID) " +
                 "Values " +
                    "('Clips', 5.33, 'Clips para papel', 50, 'clips1.jpg', 2) "
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Products");
        }
    }
}
