using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OmniWallet.Database.Migrations
{
    public partial class CriadoTabelaPessoasJuridicas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pessoas_juridicas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nome_fantasia = table.Column<string>(maxLength: 255, nullable: false),
                    razao_social = table.Column<string>(maxLength: 255, nullable: false),
                    dominio = table.Column<string>(maxLength: 10, nullable: false),
                    cnpj = table.Column<string>(fixedLength: true, maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pessoas_juridicas", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_pessoas_juridicas_cnpj",
                table: "pessoas_juridicas",
                column: "cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_pessoas_juridicas_dominio",
                table: "pessoas_juridicas",
                column: "dominio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_pessoas_juridicas_razao_social",
                table: "pessoas_juridicas",
                column: "razao_social",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pessoas_juridicas");
        }
    }
}
