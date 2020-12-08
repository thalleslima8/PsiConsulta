using Microsoft.EntityFrameworkCore.Migrations;

namespace PsiConsulta.Migrations
{
    public partial class InfosPsicologos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Psicologo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Psicologo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Psicologo");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Psicologo");
        }
    }
}
