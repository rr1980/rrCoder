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
                    Name = table.Column<string>(nullable: true),
                    Vorname = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodeSnippet",
                schema: "rrCoder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Erstellt_Datum = table.Column<DateTime>(nullable: false),
                    Erstellt_UserId = table.Column<int>(nullable: true),
                    Geaendert_Datum = table.Column<DateTime>(nullable: true),
                    Geaendert_UserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Beschreibung = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeSnippet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeSnippet_User_Erstellt_UserId",
                        column: x => x.Erstellt_UserId,
                        principalSchema: "rrCoder",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CodeSnippet_User_Geaendert_UserId",
                        column: x => x.Geaendert_UserId,
                        principalSchema: "rrCoder",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Name = table.Column<string>(nullable: true),
                    Beschreibung = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    CodeSnippetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeContent_CodeSnippet_CodeSnippetId",
                        column: x => x.CodeSnippetId,
                        principalSchema: "rrCoder",
                        principalTable: "CodeSnippet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    CodeSnippetId = table.Column<int>(nullable: true),
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
                        name: "FK_Bemerkung_CodeSnippet_CodeSnippetId",
                        column: x => x.CodeSnippetId,
                        principalSchema: "rrCoder",
                        principalTable: "CodeSnippet",
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
                name: "IX_Bemerkung_CodeSnippetId",
                schema: "rrCoder",
                table: "Bemerkung",
                column: "CodeSnippetId");

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
                name: "IX_CodeContent_CodeSnippetId",
                schema: "rrCoder",
                table: "CodeContent",
                column: "CodeSnippetId");

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

            migrationBuilder.CreateIndex(
                name: "IX_CodeSnippet_Erstellt_UserId",
                schema: "rrCoder",
                table: "CodeSnippet",
                column: "Erstellt_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeSnippet_Geaendert_UserId",
                schema: "rrCoder",
                table: "CodeSnippet",
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
                name: "CodeSnippet",
                schema: "rrCoder");

            migrationBuilder.DropTable(
                name: "User",
                schema: "rrCoder");
        }
    }
}
