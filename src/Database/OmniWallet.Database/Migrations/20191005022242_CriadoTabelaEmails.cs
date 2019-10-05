using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OmniWallet.Database.Migrations
{
    public partial class CriadoTabelaEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "emails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_pessoa = table.Column<int>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    tipo = table.Column<byte>(nullable: false),
                    valor = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_emails", x => x.id);
                    table.ForeignKey(
                        name: "fk_emails_pessoas_id_pessoa",
                        column: x => x.id_pessoa,
                        principalTable: "pessoas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_emails_id_pessoa",
                table: "emails",
                column: "id_pessoa");

            migrationBuilder.CreateIndex(
                name: "ix_emails_valor",
                table: "emails",
                column: "valor",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emails");
        }
    }
}
