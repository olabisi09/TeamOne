using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class TryAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WebUsers_gradeID",
                table: "WebUsers",
                column: "gradeID");

            migrationBuilder.AddForeignKey(
                name: "FK_WebUsers_Grades_gradeID",
                table: "WebUsers",
                column: "gradeID",
                principalTable: "Grades",
                principalColumn: "GradeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebUsers_Grades_gradeID",
                table: "WebUsers");

            migrationBuilder.DropIndex(
                name: "IX_WebUsers_gradeID",
                table: "WebUsers");
        }
    }
}
