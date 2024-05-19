using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProducao.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO produto(categoriaid, nome, descricao, preco, imagemurl, estoque, datacadastro) " +
                "VALUES (1,'Coca-Cola Diet', 'Refrigerante de Cola 350ml', 5.45, 'coca-cola.png', 50, now());");
            migrationBuilder.Sql("INSERT INTO produto(categoriaid, nome, descricao, preco, imagemurl, estoque, datacadastro) " +
                "VALUES (2,'Lanche de Atum', 'Lanche de Atum com maionese', 8.50, 'atum.jpg', 10, now());");
            migrationBuilder.Sql("INSERT INTO produto(categoriaid, nome, descricao, preco, imagemurl, estoque, datacadastro) " +
                "VALUES (3,'Pudim 100g', 'Pudim de Leite condensado 100g', 6.75, 'pudim.png', 20, now());");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM produto");
        }
    }
}
