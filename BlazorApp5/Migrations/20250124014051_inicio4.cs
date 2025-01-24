using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp5.Migrations
{
    /// <inheritdoc />
    public partial class inicio4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscals_Clientes_ClienteId",
                table: "NotaFiscals");

            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscals_Fornecedore_FornecedorId",
                table: "NotaFiscals");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscals_ClienteId",
                table: "NotaFiscals");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscals_FornecedorId",
                table: "NotaFiscals");

            migrationBuilder.AddColumn<string>(
                name: "NomeCliente",
                table: "NotaFiscals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeFornecedor",
                table: "NotaFiscals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeCliente",
                table: "NotaFiscals");

            migrationBuilder.DropColumn(
                name: "NomeFornecedor",
                table: "NotaFiscals");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscals_ClienteId",
                table: "NotaFiscals",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscals_FornecedorId",
                table: "NotaFiscals",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscals_Clientes_ClienteId",
                table: "NotaFiscals",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscals_Fornecedore_FornecedorId",
                table: "NotaFiscals",
                column: "FornecedorId",
                principalTable: "Fornecedore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
