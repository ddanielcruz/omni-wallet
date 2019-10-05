using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OmniWallet.Database.Migrations
{
    public partial class CriadoTabelaEnderecos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    id_pessoa = table.Column<int>(nullable: false),
                    id_cidade = table.Column<int>(nullable: false),
                    rua = table.Column<string>(maxLength: 50, nullable: false),
                    numero = table.Column<string>(maxLength: 10, nullable: false),
                    bairro = table.Column<string>(maxLength: 20, nullable: false),
                    complemento = table.Column<string>(maxLength: 20, nullable: true),
                    cep = table.Column<string>(maxLength: 10, nullable: false),
                    referencia = table.Column<string>(maxLength: 256, nullable: true),
                    tipo = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_enderecos", x => x.id);
                    table.ForeignKey(
                        name: "fk_enderecos_cidades_id_cidade",
                        column: x => x.id_cidade,
                        principalTable: "cidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_enderecos_pessoas_id_pessoa",
                        column: x => x.id_pessoa,
                        principalTable: "pessoas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_enderecos_id_cidade",
                table: "enderecos",
                column: "id_cidade");

            migrationBuilder.CreateIndex(
                name: "ix_enderecos_id_pessoa",
                table: "enderecos",
                column: "id_pessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enderecos");
        }
    }
}
