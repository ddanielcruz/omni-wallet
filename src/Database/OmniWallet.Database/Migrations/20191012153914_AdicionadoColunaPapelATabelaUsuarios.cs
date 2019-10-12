using Microsoft.EntityFrameworkCore.Migrations;

namespace OmniWallet.Database.Migrations
{
    public partial class AdicionadoColunaPapelATabelaUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "papel",
                table: "usuarios",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "papel",
                table: "usuarios");
        }
    }
}
