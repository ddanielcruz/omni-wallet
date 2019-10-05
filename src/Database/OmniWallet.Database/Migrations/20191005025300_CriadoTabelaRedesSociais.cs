using Microsoft.EntityFrameworkCore.Migrations;

namespace OmniWallet.Database.Migrations
{
    public partial class CriadoTabelaRedesSociais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "redes_sociais",
                columns: table => new
                {
                    id = table.Column<byte>(nullable: false),
                    nome = table.Column<string>(maxLength: 32, nullable: false),
                    integrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_redes_sociais", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pessoas_redes_sociais",
                columns: table => new
                {
                    id_pessoa = table.Column<int>(nullable: false),
                    id_rede_social = table.Column<byte>(nullable: false),
                    perfil = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pessoas_redes_sociais", x => new { x.id_pessoa, x.id_rede_social });
                    table.ForeignKey(
                        name: "fk_pessoas_redes_sociais_pessoas_id_pessoa",
                        column: x => x.id_pessoa,
                        principalTable: "pessoas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_pessoas_redes_sociais_redes_sociais_id_rede_social",
                        column: x => x.id_rede_social,
                        principalTable: "redes_sociais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_pessoas_redes_sociais_id_rede_social",
                table: "pessoas_redes_sociais",
                column: "id_rede_social");

            migrationBuilder.CreateIndex(
                name: "ix_redes_sociais_nome",
                table: "redes_sociais",
                column: "nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pessoas_redes_sociais");

            migrationBuilder.DropTable(
                name: "redes_sociais");
        }
    }
}
