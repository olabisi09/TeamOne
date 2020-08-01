using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class MoreAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "step",
                table: "Grades",
                newName: "Step");

            migrationBuilder.RenameColumn(
                name: "level",
                table: "Grades",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "gradeName",
                table: "Grades",
                newName: "GradeName");

            migrationBuilder.RenameColumn(
                name: "gradeID",
                table: "Grades",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Step",
                table: "Grades",
                newName: "step");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Grades",
                newName: "level");

            migrationBuilder.RenameColumn(
                name: "GradeName",
                table: "Grades",
                newName: "gradeName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Grades",
                newName: "gradeID");
        }
    }
}
