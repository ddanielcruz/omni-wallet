using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OmniWallet.Database.Migrations
{
    public partial class CriadoTabelasPermissoesEUsuariosPermissoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "permissoes",
                columns: table => new
                {
                    id = table.Column<short>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nome = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissoes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios_permissoes",
                columns: table => new
                {
                    id_usuario = table.Column<int>(nullable: false),
                    id_permissao = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuarios_permissoes", x => new { x.id_usuario, x.id_permissao });
                    table.ForeignKey(
                        name: "fk_usuarios_permissoes_permissoes_id_permissao",
                        column: x => x.id_permissao,
                        principalTable: "permissoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_usuarios_permissoes_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_permissoes_nome",
                table: "permissoes",
                column: "nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_usuarios_permissoes_id_permissao",
                table: "usuarios_permissoes",
                column: "id_permissao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios_permissoes");

            migrationBuilder.DropTable(
                name: "permissoes");
        }
    }
}
