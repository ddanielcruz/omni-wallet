using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OmniWallet.Database.Migrations
{
    public partial class CriadoTabelaProfissoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "id_profissao",
                table: "pessoas_fisicas_fiscal",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "profissoes",
                columns: table => new
                {
                    id = table.Column<short>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profissoes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_pessoas_fisicas_fiscal_id_profissao",
                table: "pessoas_fisicas_fiscal",
                column: "id_profissao");

            migrationBuilder.AddForeignKey(
                name: "fk_pessoas_fisicas_fiscal_profissoes_id_profissao",
                table: "pessoas_fisicas_fiscal",
                column: "id_profissao",
                principalTable: "profissoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pessoas_fisicas_fiscal_profissoes_id_profissao",
                table: "pessoas_fisicas_fiscal");

            migrationBuilder.DropTable(
                name: "profissoes");

            migrationBuilder.DropIndex(
                name: "ix_pessoas_fisicas_fiscal_id_profissao",
                table: "pessoas_fisicas_fiscal");

            migrationBuilder.DropColumn(
                name: "id_profissao",
                table: "pessoas_fisicas_fiscal");
        }
    }
}
