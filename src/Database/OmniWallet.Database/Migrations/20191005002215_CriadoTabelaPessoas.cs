using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OmniWallet.Database.Migrations
{
    public partial class CriadoTabelaPessoas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pessoas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_pessoa_fisica = table.Column<int>(nullable: true),
                    id_pessoa_juridica = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pessoas", x => x.id);
                    table.ForeignKey(
                        name: "fk_pessoas_pessoas_fisicas_id_pessoa_fisica",
                        column: x => x.id_pessoa_fisica,
                        principalTable: "pessoas_fisicas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pessoas_pessoas_juridicas_id_pessoa_juridica",
                        column: x => x.id_pessoa_juridica,
                        principalTable: "pessoas_juridicas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_pessoas_id_pessoa_fisica",
                table: "pessoas",
                column: "id_pessoa_fisica",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_pessoas_id_pessoa_juridica",
                table: "pessoas",
                column: "id_pessoa_juridica",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pessoas");
        }
    }
}
