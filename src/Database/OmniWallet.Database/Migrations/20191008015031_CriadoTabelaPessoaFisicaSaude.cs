using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OmniWallet.Database.Migrations
{
    public partial class CriadoTabelaPessoaFisicaSaude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_pessoa_fisica_saude",
                table: "pessoas_fisicas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "pessoas_fisicas_saudes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    fuma = table.Column<bool>(nullable: true),
                    frequencia_bebida = table.Column<byte>(nullable: true),
                    frequencia_esportes = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pessoas_fisicas_saudes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_pessoas_fisicas_id_pessoa_fisica_saude",
                table: "pessoas_fisicas",
                column: "id_pessoa_fisica_saude",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_pessoas_fisicas_pessoas_fisicas_saudes_id_pessoa_fisica_sau~",
                table: "pessoas_fisicas",
                column: "id_pessoa_fisica_saude",
                principalTable: "pessoas_fisicas_saudes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pessoas_fisicas_pessoas_fisicas_saudes_id_pessoa_fisica_sau~",
                table: "pessoas_fisicas");

            migrationBuilder.DropTable(
                name: "pessoas_fisicas_saudes");

            migrationBuilder.DropIndex(
                name: "ix_pessoas_fisicas_id_pessoa_fisica_saude",
                table: "pessoas_fisicas");

            migrationBuilder.DropColumn(
                name: "id_pessoa_fisica_saude",
                table: "pessoas_fisicas");
        }
    }
}
