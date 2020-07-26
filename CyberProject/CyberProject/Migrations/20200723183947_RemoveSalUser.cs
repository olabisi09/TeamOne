using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class RemoveSalUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetSalary",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "TaxOnSalary",
                table: "WebUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "NetSalary",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Salary",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TaxOnSalary",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
