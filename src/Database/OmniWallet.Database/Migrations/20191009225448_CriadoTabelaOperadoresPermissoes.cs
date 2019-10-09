using Microsoft.EntityFrameworkCore.Migrations;

namespace OmniWallet.Database.Migrations
{
    public partial class CriadoTabelaOperadoresPermissoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "operadores_permissoes",
                columns: table => new
                {
                    id_operador = table.Column<int>(nullable: false),
                    id_permissao = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_operadores_permissoes", x => new { x.id_operador, x.id_permissao });
                    table.ForeignKey(
                        name: "fk_operadores_permissoes_operadores_id_operador",
                        column: x => x.id_operador,
                        principalTable: "operadores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_operadores_permissoes_permissoes_id_permissao",
                        column: x => x.id_permissao,
                        principalTable: "permissoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_operadores_permissoes_id_permissao",
                table: "operadores_permissoes",
                column: "id_permissao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "operadores_permissoes");
        }
    }
}
