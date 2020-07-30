using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class MuchMore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpLevel",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "NetSalary",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "Step",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "TaxOnSalary",
                table: "WebUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpLevel",
                table: "WebUsers",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "NetSalary",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "WebUsers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "WebUsers",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Salary",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Step",
                table: "WebUsers",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TaxOnSalary",
                table: "WebUsers",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
