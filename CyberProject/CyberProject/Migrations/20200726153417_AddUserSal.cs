using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class AddUserSal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_WebUsers_DepartmentID",
                table: "WebUsers",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_WebUsers_FacultyID",
                table: "WebUsers",
                column: "FacultyID");

            migrationBuilder.AddForeignKey(
                name: "FK_WebUsers_Departments_DepartmentID",
                table: "WebUsers",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "deptID");

            migrationBuilder.AddForeignKey(
                name: "FK_WebUsers_Faculties_FacultyID",
                table: "WebUsers",
                column: "FacultyID",
                principalTable: "Faculties",
                principalColumn: "facultyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebUsers_Departments_DepartmentID",
                table: "WebUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_WebUsers_Faculties_FacultyID",
                table: "WebUsers");

            migrationBuilder.DropIndex(
                name: "IX_WebUsers_DepartmentID",
                table: "WebUsers");

            migrationBuilder.DropIndex(
                name: "IX_WebUsers_FacultyID",
                table: "WebUsers");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_UserID",
                table: "Salaries");

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
    }
}
