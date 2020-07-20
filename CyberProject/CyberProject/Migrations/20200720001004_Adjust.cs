using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class Adjust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Faculties_facultyID",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "facultyID",
                table: "Departments",
                newName: "FacultyID");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_facultyID",
                table: "Departments",
                newName: "IX_Departments_FacultyID");

            migrationBuilder.AlterColumn<int>(
                name: "FacultyID",
                table: "Departments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Faculties_FacultyID",
                table: "Departments",
                column: "FacultyID",
                principalTable: "Faculties",
                principalColumn: "facultyID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Faculties_FacultyID",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "FacultyID",
                table: "Departments",
                newName: "facultyID");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_FacultyID",
                table: "Departments",
                newName: "IX_Departments_facultyID");

            migrationBuilder.AlterColumn<int>(
                name: "facultyID",
                table: "Departments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Faculties_facultyID",
                table: "Departments",
                column: "facultyID",
                principalTable: "Faculties",
                principalColumn: "facultyID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
