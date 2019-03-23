using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "rrCoder");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "rrCoder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeContent",
                schema: "rrCoder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Betreff = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeContent_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "rrCoder",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bemerkung",
                schema: "rrCoder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Betreff = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    CodeContentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bemerkung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bemerkung_CodeContent_CodeContentId",
                        column: x => x.CodeContentId,
                        principalSchema: "rrCoder",
                        principalTable: "CodeContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bemerkung_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "rrCoder",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aenderungen",
                schema: "rrCoder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    CodeContentId = table.Column<int>(nullable: true),
                    BemerkungId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aenderungen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aenderungen_Bemerkung_BemerkungId",
                        column: x => x.BemerkungId,
                        principalSchema: "rrCoder",
                        principalTable: "Bemerkung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aenderungen_CodeContent_CodeContentId",
                        column: x => x.CodeContentId,
                        principalSchema: "rrCoder",
                        principalTable: "CodeContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aenderungen_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "rrCoder",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aenderungen_BemerkungId",
                schema: "rrCoder",
                table: "Aenderungen",
                column: "BemerkungId");

            migrationBuilder.CreateIndex(
                name: "IX_Aenderungen_CodeContentId",
                schema: "rrCoder",
                table: "Aenderungen",
                column: "CodeContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Aenderungen_UserId",
                schema: "rrCoder",
                table: "Aenderungen",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bemerkung_CodeContentId",
                schema: "rrCoder",
                table: "Bemerkung",
                column: "CodeContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bemerkung_UserId",
                schema: "rrCoder",
                table: "Bemerkung",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeContent_UserId",
                schema: "rrCoder",
                table: "CodeContent",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aenderungen",
                schema: "rrCoder");

            migrationBuilder.DropTable(
                name: "Bemerkung",
                schema: "rrCoder");

            migrationBuilder.DropTable(
                name: "CodeContent",
                schema: "rrCoder");

            migrationBuilder.DropTable(
                name: "User",
                schema: "rrCoder");
        }
    }
}
