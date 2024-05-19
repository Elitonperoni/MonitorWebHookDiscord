using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProducao.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO categoria(nome, imagemurl) VALUES('Bebidas', 'bebidas.jpg')");
            migrationBuilder.Sql("INSERT INTO categoria(nome, imagemurl) VALUES('Lanches', 'lanches.jpg')");
            migrationBuilder.Sql("INSERT INTO categoria(nome, imagemurl) VALUES('Sobremesas', 'sobremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM categoria");
        }
    }
}
