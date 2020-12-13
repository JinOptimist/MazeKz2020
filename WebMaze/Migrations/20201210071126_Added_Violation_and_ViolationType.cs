using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class Added_Violation_and_ViolationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypesOfViolation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Punishment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermOfPunishment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Penalty = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfViolation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Violations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    BlamingPolicemanId = table.Column<long>(type: "bigint", nullable: true),
                    TypeOfViolationId = table.Column<long>(type: "bigint", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Violations_CitizenUser_UserId",
                        column: x => x.UserId,
                        principalTable: "CitizenUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Violations_Policemen_BlamingPolicemanId",
                        column: x => x.BlamingPolicemanId,
                        principalTable: "Policemen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Violations_TypesOfViolation_TypeOfViolationId",
                        column: x => x.TypeOfViolationId,
                        principalTable: "TypesOfViolation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Violations_BlamingPolicemanId",
                table: "Violations",
                column: "BlamingPolicemanId");

            migrationBuilder.CreateIndex(
                name: "IX_Violations_TypeOfViolationId",
                table: "Violations",
                column: "TypeOfViolationId");

            migrationBuilder.CreateIndex(
                name: "IX_Violations_UserId",
                table: "Violations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Violations");

            migrationBuilder.DropTable(
                name: "TypesOfViolation");
        }
    }
}
