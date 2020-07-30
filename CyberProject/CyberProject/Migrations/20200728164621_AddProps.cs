using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class AddProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "WebUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LGA",
                table: "WebUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "WebUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "LGA",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "WebUsers");
        }
    }
}
