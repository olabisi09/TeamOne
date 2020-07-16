using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class NextPhase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.AlterColumn<string>(
                name: "gradeName",
                table: "Grades",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "gradeID",
                table: "Grades",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                column: "gradeID");

            migrationBuilder.CreateTable(
                name: "WebUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    DepartmentID = table.Column<int>(nullable: false),
                    FacultyID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Dateregistered = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebUsers_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "deptID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebUsers_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "facultyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WebUsers_DepartmentID",
                table: "WebUsers",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_WebUsers_FacultyID",
                table: "WebUsers",
                column: "FacultyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "gradeID",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "gradeName",
                table: "Grades",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                column: "gradeName");
        }
    }
}
