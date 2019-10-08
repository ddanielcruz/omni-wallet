using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OmniWallet.Database.Migrations
{
    public partial class CriadoTabelaPessoaFisicaFiscal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_pessoa_fisica_fiscal",
                table: "pessoas_fisicas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "pessoas_fisicas_fiscal",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    empresa_trabalho = table.Column<string>(maxLength: 50, nullable: true),
                    rg = table.Column<string>(maxLength: 20, nullable: true),
                    cpf = table.Column<string>(fixedLength: true, maxLength: 11, nullable: true),
                    cnh = table.Column<string>(fixedLength: true, maxLength: 11, nullable: true),
                    estado_civil = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pessoas_fisicas_fiscal", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_pessoas_fisicas_id_pessoa_fisica_fiscal",
                table: "pessoas_fisicas",
                column: "id_pessoa_fisica_fiscal",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_pessoas_fisicas_pessoas_fisicas_fiscal_id_pessoa_fisica_fis~",
                table: "pessoas_fisicas",
                column: "id_pessoa_fisica_fiscal",
                principalTable: "pessoas_fisicas_fiscal",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pessoas_fisicas_pessoas_fisicas_fiscal_id_pessoa_fisica_fis~",
                table: "pessoas_fisicas");

            migrationBuilder.DropTable(
                name: "pessoas_fisicas_fiscal");

            migrationBuilder.DropIndex(
                name: "ix_pessoas_fisicas_id_pessoa_fisica_fiscal",
                table: "pessoas_fisicas");

            migrationBuilder.DropColumn(
                name: "id_pessoa_fisica_fiscal",
                table: "pessoas_fisicas");
        }
    }
}
