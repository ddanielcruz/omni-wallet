using Microsoft.EntityFrameworkCore.Migrations;

namespace OmniWallet.Database.Migrations
{
    public partial class RelacionadoTabelasUsuarioPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_usuario",
                table: "pessoas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_pessoas_id_usuario",
                table: "pessoas",
                column: "id_usuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_pessoas_usuarios_id_usuario",
                table: "pessoas",
                column: "id_usuario",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_pessoas_usuarios_id_usuario",
                table: "pessoas");

            migrationBuilder.DropIndex(
                name: "ix_pessoas_id_usuario",
                table: "pessoas");

            migrationBuilder.DropColumn(
                name: "id_usuario",
                table: "pessoas");
        }
    }
}
