using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class Deleted_ValidationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Violations_TypesOfViolation_TypeOfViolationId",
                table: "Violations");

            migrationBuilder.DropTable(
                name: "TypesOfViolation");

            migrationBuilder.DropIndex(
                name: "IX_Violations_TypeOfViolationId",
                table: "Violations");

            migrationBuilder.DropColumn(
                name: "TypeOfViolationId",
                table: "Violations");

            migrationBuilder.AddColumn<string>(
                name: "Article",
                table: "Violations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Penalty",
                table: "Violations",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Punishment",
                table: "Violations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TermOfPunishment",
                table: "Violations",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Article",
                table: "Violations");

            migrationBuilder.DropColumn(
                name: "Penalty",
                table: "Violations");

            migrationBuilder.DropColumn(
                name: "Punishment",
                table: "Violations");

            migrationBuilder.DropColumn(
                name: "TermOfPunishment",
                table: "Violations");

            migrationBuilder.AddColumn<long>(
                name: "TypeOfViolationId",
                table: "Violations",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypesOfViolation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Penalty = table.Column<decimal>(type: "money", nullable: true),
                    Punishment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermOfPunishment = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfViolation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Violations_TypeOfViolationId",
                table: "Violations",
                column: "TypeOfViolationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Violations_TypesOfViolation_TypeOfViolationId",
                table: "Violations",
                column: "TypeOfViolationId",
                principalTable: "TypesOfViolation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
