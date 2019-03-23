using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class Init : Migration
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
                    Erstellt_Datum = table.Column<DateTime>(nullable: false),
                    Erstellt_UserId = table.Column<int>(nullable: true),
                    Geaendert_Datum = table.Column<DateTime>(nullable: true),
                    Geaendert_UserId = table.Column<int>(nullable: true),
                    Betreff = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeContent_User_Erstellt_UserId",
                        column: x => x.Erstellt_UserId,
                        principalSchema: "rrCoder",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CodeContent_User_Geaendert_UserId",
                        column: x => x.Geaendert_UserId,
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
                    Erstellt_Datum = table.Column<DateTime>(nullable: false),
                    Erstellt_UserId = table.Column<int>(nullable: true),
                    Geaendert_Datum = table.Column<DateTime>(nullable: true),
                    Geaendert_UserId = table.Column<int>(nullable: true),
                    Betreff = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
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
                        name: "FK_Bemerkung_User_Erstellt_UserId",
                        column: x => x.Erstellt_UserId,
                        principalSchema: "rrCoder",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bemerkung_User_Geaendert_UserId",
                        column: x => x.Geaendert_UserId,
                        principalSchema: "rrCoder",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bemerkung_CodeContentId",
                schema: "rrCoder",
                table: "Bemerkung",
                column: "CodeContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bemerkung_Erstellt_UserId",
                schema: "rrCoder",
                table: "Bemerkung",
                column: "Erstellt_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bemerkung_Geaendert_UserId",
                schema: "rrCoder",
                table: "Bemerkung",
                column: "Geaendert_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeContent_Erstellt_UserId",
                schema: "rrCoder",
                table: "CodeContent",
                column: "Erstellt_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeContent_Geaendert_UserId",
                schema: "rrCoder",
                table: "CodeContent",
                column: "Geaendert_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
