using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class RemoveEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "WebUsers",
                newName: "TransportPayType");

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Housing",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "HousingPayType",
                table: "WebUsers",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Lunch",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "LunchPayType",
                table: "WebUsers",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Medical",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "MedicalPayType",
                table: "WebUsers",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "NetSalary",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Tax",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "TaxPayType",
                table: "WebUsers",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TaxPercentage",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Transport",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "Housing",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "HousingPayType",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "Lunch",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "LunchPayType",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "Medical",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "MedicalPayType",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "NetSalary",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "TaxPayType",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "Transport",
                table: "WebUsers");

            migrationBuilder.RenameColumn(
                name: "TransportPayType",
                table: "WebUsers",
                newName: "Email");
        }
    }
}
