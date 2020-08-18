using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class NewForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Grades_GradeId",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_WebUsers_UserId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_GradeId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_UserId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Salaries");

            migrationBuilder.AddColumn<int>(
                name: "SalaryID",
                table: "Grades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SalaryID",
                table: "Grades",
                column: "SalaryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Salaries_SalaryID",
                table: "Grades",
                column: "SalaryID",
                principalTable: "Salaries",
                principalColumn: "SalaryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Salaries_SalaryID",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_SalaryID",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "SalaryID",
                table: "Grades");

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Salaries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Salaries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_GradeId",
                table: "Salaries",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_UserId",
                table: "Salaries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Grades_GradeId",
                table: "Salaries",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "GradeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_WebUsers_UserId",
                table: "Salaries",
                column: "UserId",
                principalTable: "WebUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
