using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lazergo.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BairroTer",
                table: "agendaModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CEPTer",
                table: "agendaModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CelularTer",
                table: "agendaModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CidadeTer",
                table: "agendaModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "EnderecoTer",
                table: "agendaModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NumeroTer",
                table: "agendaModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProprietarioTer",
                table: "agendaModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UFTer",
                table: "agendaModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BairroTer",
                table: "agendaModels");

            migrationBuilder.DropColumn(
                name: "CEPTer",
                table: "agendaModels");

            migrationBuilder.DropColumn(
                name: "CelularTer",
                table: "agendaModels");

            migrationBuilder.DropColumn(
                name: "CidadeTer",
                table: "agendaModels");

            migrationBuilder.DropColumn(
                name: "EnderecoTer",
                table: "agendaModels");

            migrationBuilder.DropColumn(
                name: "NumeroTer",
                table: "agendaModels");

            migrationBuilder.DropColumn(
                name: "ProprietarioTer",
                table: "agendaModels");

            migrationBuilder.DropColumn(
                name: "UFTer",
                table: "agendaModels");
        }
    }
}
