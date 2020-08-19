using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class Hoping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "WebUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WebUsers_ApplicationUserId",
                table: "WebUsers",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WebUsers_AspNetUsers_ApplicationUserId",
                table: "WebUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebUsers_AspNetUsers_ApplicationUserId",
                table: "WebUsers");

            migrationBuilder.DropIndex(
                name: "IX_WebUsers_ApplicationUserId",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "WebUsers");
        }
    }
}
