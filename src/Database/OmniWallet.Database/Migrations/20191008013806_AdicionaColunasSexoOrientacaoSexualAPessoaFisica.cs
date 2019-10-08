using Microsoft.EntityFrameworkCore.Migrations;

namespace OmniWallet.Database.Migrations
{
    public partial class AdicionaColunasSexoOrientacaoSexualAPessoaFisica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "orientacao_sexual",
                table: "pessoas_fisicas",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "sexo",
                table: "pessoas_fisicas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orientacao_sexual",
                table: "pessoas_fisicas");

            migrationBuilder.DropColumn(
                name: "sexo",
                table: "pessoas_fisicas");
        }
    }
}
