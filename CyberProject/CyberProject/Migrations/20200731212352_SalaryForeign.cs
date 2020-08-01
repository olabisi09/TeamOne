using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class SalaryForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Salaries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_GradeId",
                table: "Salaries",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Grades_GradeId",
                table: "Salaries",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "GradeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Grades_GradeId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_GradeId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Salaries");
        }
    }
}
