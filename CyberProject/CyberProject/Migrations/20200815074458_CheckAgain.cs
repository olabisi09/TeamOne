using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class CheckAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Step",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GradeName",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "deptName",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_GradeName_Level_Step",
                table: "Grades",
                columns: new[] { "GradeName", "Level", "Step" },
                unique: true,
                filter: "[GradeName] IS NOT NULL AND [Level] IS NOT NULL AND [Step] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_deptName",
                table: "Departments",
                column: "deptName",
                unique: true,
                filter: "[deptName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Grades_GradeName_Level_Step",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Departments_deptName",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "Step",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GradeName",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "deptName",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
