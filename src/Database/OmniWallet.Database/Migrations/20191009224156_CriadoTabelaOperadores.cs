using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OmniWallet.Database.Migrations
{
    public partial class CriadoTabelaOperadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "operadores",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_pessoa_juridica = table.Column<int>(nullable: false),
                    login = table.Column<string>(maxLength: 32, nullable: false),
                    senha_hash = table.Column<byte[]>(fixedLength: true, maxLength: 64, nullable: false),
                    senha_salt = table.Column<byte[]>(fixedLength: true, maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_operadores", x => x.id);
                    table.ForeignKey(
                        name: "fk_operadores_pessoas_juridicas_id_pessoa_juridica",
                        column: x => x.id_pessoa_juridica,
                        principalTable: "pessoas_juridicas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_operadores_id_pessoa_juridica",
                table: "operadores",
                column: "id_pessoa_juridica");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "operadores");
        }
    }
}
