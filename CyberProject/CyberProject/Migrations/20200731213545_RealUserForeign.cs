using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class RealUserForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "gradeID",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gradeID",
                table: "WebUsers");
        }
    }
}
