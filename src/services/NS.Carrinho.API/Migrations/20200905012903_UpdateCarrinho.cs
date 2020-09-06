using Microsoft.EntityFrameworkCore.Migrations;

namespace NS.Carrinho.API.Migrations
{
    public partial class UpdateCarrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItens_carrinhoClientes_CarrinhoId",
                table: "CarrinhoItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_carrinhoClientes",
                table: "carrinhoClientes");

            migrationBuilder.RenameTable(
                name: "carrinhoClientes",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItens_CarrinhoClientes_CarrinhoId",
                table: "CarrinhoItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoClientes",
                table: "CarrinhoClientes");

            migrationBuilder.RenameTable(
                name: "CarrinhoClientes",
                newName: "carrinhoClientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_carrinhoClientes",
                table: "carrinhoClientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItens_carrinhoClientes_CarrinhoId",
                table: "CarrinhoItens",
                column: "CarrinhoId",
                principalTable: "carrinhoClientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
