using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "rrCoder",
                table: "User",
                newName: "Vorname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "rrCoder",
                table: "User",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vorname",
                schema: "rrCoder",
                table: "User",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "rrCoder",
                table: "User",
                newName: "FirstName");
        }
    }
}
