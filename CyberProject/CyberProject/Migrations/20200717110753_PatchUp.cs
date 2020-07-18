using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class PatchUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dateregistered",
                table: "WebUsers");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "WebUsers",
                newName: "Step");

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "WebUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "WebUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "WebUsers");

            migrationBuilder.RenameColumn(
                name: "Step",
                table: "WebUsers",
                newName: "Role");

            migrationBuilder.AddColumn<DateTime>(
                name: "Dateregistered",
                table: "WebUsers",
                nullable: true);
        }
    }
}
