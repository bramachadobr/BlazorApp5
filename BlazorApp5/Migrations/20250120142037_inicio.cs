using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp5.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RasaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNPJ_CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inscricao_estadual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inscricao_Municipal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RasaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNPJ_CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inscricao_estadual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inscricao_Municipal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscals",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroNF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodigoValidacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FornecedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DescricaoDoServico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ValorIss = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    AliquotaIss = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataExercicio = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaFiscals_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotaFiscals_Fornecedore_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedore",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscals_ClienteId",
                table: "NotaFiscals",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscals_FornecedorId",
                table: "NotaFiscals",
                column: "FornecedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "NotaFiscals");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Fornecedore");
        }
    }
}
