using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class Addmore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "Grades",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Housing",
                table: "Grades",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "HousingPayType",
                table: "Grades",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Lunch",
                table: "Grades",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "LunchPayType",
                table: "Grades",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Medical",
                table: "Grades",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "MedicalPayType",
                table: "Grades",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "NetSalary",
                table: "Grades",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Tax",
                table: "Grades",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "TaxPayType",
                table: "Grades",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TaxPercentage",
                table: "Grades",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Transport",
                table: "Grades",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "TransportPayType",
                table: "Grades",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Housing",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "HousingPayType",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Lunch",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "LunchPayType",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Medical",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "MedicalPayType",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "NetSalary",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "TaxPayType",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Transport",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "TransportPayType",
                table: "Grades");

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
    }
}
