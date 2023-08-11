using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO CATEGORIAS (NOME, ImageUrl) VALUES ('Bebidas', 'bebidas.jpg')");
            mb.Sql("INSERT INTO CATEGORIAS (NOME, ImageUrl) VALUES ('Lanches', 'lanches.jpg')");
            mb.Sql("INSERT INTO CATEGORIAS (NOME, ImageUrl) VALUES ('Sobremesas', 'sobremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM CATEGORIAS");
        }
    }
}
