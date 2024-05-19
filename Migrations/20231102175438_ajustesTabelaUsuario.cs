using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProducao.Migrations
{
    /// <inheritdoc />
    public partial class ajustesTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "usuario",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "usuario",
                newName: "senha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "senha",
                table: "usuario",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "usuario",
                newName: "username");
        }
    }
}
