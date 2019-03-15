using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GA.XYZ.LeT.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 16, nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    PeriodoVigenciaFim = table.Column<DateTime>(maxLength: 8, nullable: true),
                    PeriodoVigenciaInicio = table.Column<DateTime>(maxLength: 8, nullable: false),
                    ValorMaxDemanda = table.Column<decimal>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 16, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    IdFornecedor = table.Column<Guid>(maxLength: 16, nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: true),
                    Telefone = table.Column<int>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contatos_Fornecedores_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_IdFornecedor",
                table: "Contatos",
                column: "IdFornecedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
