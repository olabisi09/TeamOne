using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class HadTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HousingPercentage",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "LunchPercentage",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "MedicalPercentage",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "TransportPercentage",
                table: "Salaries");

            migrationBuilder.AlterColumn<string>(
                name: "TransportPayType",
                table: "Salaries",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "TaxPayType",
                table: "Salaries",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "MedicalPayType",
                table: "Salaries",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "LunchPayType",
                table: "Salaries",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "HousingPayType",
                table: "Salaries",
                nullable: true,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "TransportPayType",
                table: "Salaries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "TaxPayType",
                table: "Salaries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "MedicalPayType",
                table: "Salaries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "LunchPayType",
                table: "Salaries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "HousingPayType",
                table: "Salaries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "HousingPercentage",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LunchPercentage",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MedicalPercentage",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TaxPercentage",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TransportPercentage",
                table: "Salaries",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
