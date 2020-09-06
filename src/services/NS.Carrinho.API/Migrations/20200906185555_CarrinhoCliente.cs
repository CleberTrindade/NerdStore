using Microsoft.EntityFrameworkCore.Migrations;

namespace NS.Carrinho.API.Migrations
{
    public partial class CarrinhoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItens_CarrinhoClientes_CarrinhoId",
                table: "CarrinhoItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoClientes",
                table: "CarrinhoClientes");

            migrationBuilder.RenameTable(
                name: "CarrinhoClientes",
                newName: "CarrinhoCliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoCliente",
                table: "CarrinhoCliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItens_CarrinhoCliente_CarrinhoId",
                table: "CarrinhoItens",
                column: "CarrinhoId",
                principalTable: "CarrinhoCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItens_CarrinhoCliente_CarrinhoId",
                table: "CarrinhoItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoCliente",
                table: "CarrinhoCliente");

            migrationBuilder.RenameTable(
                name: "CarrinhoCliente",
                newName: "CarrinhoClientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoClientes",
                table: "CarrinhoClientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItens_CarrinhoClientes_CarrinhoId",
                table: "CarrinhoItens",
                column: "CarrinhoId",
                principalTable: "CarrinhoClientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
