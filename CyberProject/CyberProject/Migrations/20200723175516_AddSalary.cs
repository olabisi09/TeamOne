using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberProject.Migrations
{
    public partial class AddSalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxSalary",
                table: "WebUsers",
                newName: "TaxOnSalary");

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeID = table.Column<int>(nullable: false),
                    EmployeeGrade = table.Column<string>(nullable: true),
                    EmployeeLevel = table.Column<string>(nullable: true),
                    EmployeeStep = table.Column<string>(nullable: true),
                    Sal = table.Column<float>(nullable: false),
                    TaxOnSalary = table.Column<float>(nullable: false),
                    NetSalary = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.RenameColumn(
                name: "TaxSalary",
                table: "WebUsers",
                newName: "TaxOnSalary");
        }
    }
}
