using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class CreateMedecineCertificateAndLinkWIthCItizen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "MedicineCertificates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineCertificates_CitizenUser_UserId",
                        column: x => x.UserId,
                        principalTable: "CitizenUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            
            migrationBuilder.CreateIndex(
                name: "IX_MedicineCertificates_UserId",
                table: "MedicineCertificates",
                column: "UserId",
                unique: true);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropTable(
                name: "MedicineCertificates");

            
        }
    }
}
