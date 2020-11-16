using Microsoft.EntityFrameworkCore.Migrations;

namespace PsiConsulta.Migrations
{
    public partial class UF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Endereco",
                newName: "UF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UF",
                table: "Endereco",
                newName: "Estado");
        }
    }
}
