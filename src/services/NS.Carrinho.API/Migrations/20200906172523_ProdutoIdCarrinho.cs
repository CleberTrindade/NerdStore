using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NS.Carrinho.API.Migrations
{
    public partial class ProdutoIdCarrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "CarrinhoItens");

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "CarrinhoItens",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "CarrinhoItens");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProduto",
                table: "CarrinhoItens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
