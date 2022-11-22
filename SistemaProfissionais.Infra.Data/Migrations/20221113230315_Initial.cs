using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaProfissionais.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.IDUSUARIO);
                });

            migrationBuilder.CreateTable(
                name: "PROFISSIONAL",
                columns: table => new
                {
                    IDPROFISSIONAL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TELEFONE = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFISSIONAL", x => x.IDPROFISSIONAL);
                    table.ForeignKey(
                        name: "FK_PROFISSIONAL_USUARIO_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "IDUSUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PROFISSIONAL_CPF",
                table: "PROFISSIONAL",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PROFISSIONAL_EMAIL",
                table: "PROFISSIONAL",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PROFISSIONAL_IDUSUARIO",
                table: "PROFISSIONAL",
                column: "IDUSUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_PROFISSIONAL_TELEFONE",
                table: "PROFISSIONAL",
                column: "TELEFONE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_EMAIL",
                table: "USUARIO",
                column: "EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROFISSIONAL");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
