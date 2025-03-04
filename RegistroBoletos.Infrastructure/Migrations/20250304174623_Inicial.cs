using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroBoletos.Infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_banco",
                columns: table => new
                {
                    idbanco = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    nomebanco = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    codigobanco = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    jurosperc = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_banco", x => x.idbanco);
                });

            migrationBuilder.CreateTable(
                name: "tb_boleto",
                columns: table => new
                {
                    idboleto = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    nomepagador = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cpfcnpjpagador = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    nomebeneficiario = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cpfcnpjbeneficiario = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    valor = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false),
                    datavencimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    obs = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    idbanco = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_boleto", x => x.idboleto);
                    table.ForeignKey(
                        name: "FK_tb_boleto_tb_banco_idbanco",
                        column: x => x.idbanco,
                        principalTable: "tb_banco",
                        principalColumn: "idbanco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_boleto_idbanco",
                table: "tb_boleto",
                column: "idbanco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_boleto");

            migrationBuilder.DropTable(
                name: "tb_banco");
        }
    }
}
