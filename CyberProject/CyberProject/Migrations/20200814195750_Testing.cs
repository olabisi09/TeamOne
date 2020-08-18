using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class Testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "facultyName",
                table: "Faculties",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "facultyCode",
                table: "Faculties",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_facultyName_facultyCode",
                table: "Faculties",
                columns: new[] { "facultyName", "facultyCode" },
                unique: true,
                filter: "[facultyName] IS NOT NULL AND [facultyCode] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Faculties_facultyName_facultyCode",
                table: "Faculties");

            migrationBuilder.AlterColumn<string>(
                name: "facultyName",
                table: "Faculties",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "facultyCode",
                table: "Faculties",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
