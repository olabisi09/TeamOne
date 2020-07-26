using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class Again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "WebUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpLevel",
                table: "WebUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Step",
                table: "WebUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "EmpLevel",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "Step",
                table: "WebUsers");
        }
    }
}
