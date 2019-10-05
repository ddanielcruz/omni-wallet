using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OmniWallet.Database.Migrations
{
    public partial class CriadoTabelaEstado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_pais = table.Column<short>(nullable: false),
                    nome = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_estados", x => x.id);
                    table.ForeignKey(
                        name: "fk_estados_paises_id_pais",
                        column: x => x.id_pais,
                        principalTable: "paises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_paises_ddi",
                table: "paises",
                column: "ddi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_paises_iso2",
                table: "paises",
                column: "iso2",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_paises_iso3",
                table: "paises",
                column: "iso3",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_paises_nome",
                table: "paises",
                column: "nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_estados_id_pais",
                table: "estados",
                column: "id_pais");

            migrationBuilder.CreateIndex(
                name: "ix_estados_nome",
                table: "estados",
                column: "nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropIndex(
                name: "ix_paises_ddi",
                table: "paises");

            migrationBuilder.DropIndex(
                name: "ix_paises_iso2",
                table: "paises");

            migrationBuilder.DropIndex(
                name: "ix_paises_iso3",
                table: "paises");

            migrationBuilder.DropIndex(
                name: "ix_paises_nome",
                table: "paises");
        }
    }
}
