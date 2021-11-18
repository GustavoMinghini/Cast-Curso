using Microsoft.EntityFrameworkCore.Migrations;

namespace CastCurso.Migrations
{
    public partial class Finalx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CursoNome",
                table: "Curso",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CursoNome",
                table: "Curso");
        }
    }
}
