using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                schema: "rrCoder",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Modified",
                schema: "rrCoder",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "ModifiedEntity",
                schema: "rrCoder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedUserId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Betreff = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifiedEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModifiedEntity_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "rrCoder",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModifiedEntity_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalSchema: "rrCoder",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedEntity_UserId",
                schema: "rrCoder",
                table: "ModifiedEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedEntity_ModifiedUserId",
                schema: "rrCoder",
                table: "ModifiedEntity",
                column: "ModifiedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModifiedEntity",
                schema: "rrCoder");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "rrCoder",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                schema: "rrCoder",
                table: "Users",
                nullable: true);
        }
    }
}
