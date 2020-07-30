using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class RemoveKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebUsers_Faculties_FacultyID",
                table: "WebUsers");

            migrationBuilder.DropIndex(
                name: "IX_WebUsers_FacultyID",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "FacultyID",
                table: "WebUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacultyID",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WebUsers_FacultyID",
                table: "WebUsers",
                column: "FacultyID");

            migrationBuilder.AddForeignKey(
                name: "FK_WebUsers_Faculties_FacultyID",
                table: "WebUsers",
                column: "FacultyID",
                principalTable: "Faculties",
                principalColumn: "facultyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
