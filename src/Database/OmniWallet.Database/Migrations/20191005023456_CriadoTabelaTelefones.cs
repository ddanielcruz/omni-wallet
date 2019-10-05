using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OmniWallet.Database.Migrations
{
    public partial class CriadoTabelaTelefones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "telefones",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_pessoa = table.Column<int>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    tipo = table.Column<byte>(nullable: false),
                    id_pais = table.Column<short>(nullable: false),
                    numero = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_telefones", x => x.id);
                    table.ForeignKey(
                        name: "fk_telefones_paises_id_pais",
                        column: x => x.id_pais,
                        principalTable: "paises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_telefones_pessoas_id_pessoa",
                        column: x => x.id_pessoa,
                        principalTable: "pessoas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_telefones_id_pais",
                table: "telefones",
                column: "id_pais");

            migrationBuilder.CreateIndex(
                name: "ix_telefones_id_pessoa",
                table: "telefones",
                column: "id_pessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "telefones");
        }
    }
}
