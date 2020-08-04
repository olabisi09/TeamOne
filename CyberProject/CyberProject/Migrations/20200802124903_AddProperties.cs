using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class AddProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayItem",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "PayItemType",
                table: "Salaries");

            migrationBuilder.AddColumn<float>(
                name: "Housing",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HousingPayType",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HousingPercentage",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Lunch",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LunchPayType",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LunchPercentage",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Medical",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MedicalPayType",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MedicalPercentage",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Tax",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TaxPayType",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TaxPercentage",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Transport",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TransportPayType",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TransportPercentage",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Salaries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_UserId",
                table: "Salaries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_WebUsers_UserId",
                table: "Salaries",
                column: "UserId",
                principalTable: "WebUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_WebUsers_UserId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_UserId",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "Housing",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "HousingPayType",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "HousingPercentage",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "Lunch",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "LunchPayType",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "LunchPercentage",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "Medical",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "MedicalPayType",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "MedicalPercentage",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "TaxPayType",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "Transport",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "TransportPayType",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "TransportPercentage",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Salaries");

            migrationBuilder.AddColumn<string>(
                name: "PayItem",
                table: "Salaries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayItemType",
                table: "Salaries",
                nullable: true);
        }
    }
}
