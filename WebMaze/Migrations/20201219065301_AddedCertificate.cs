using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class AddedCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Policemen");

            migrationBuilder.AddColumn<long>(
                name: "CertificateId",
                table: "Policemen",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rank",
                table: "Policemen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Validity = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Policemen_CertificateId",
                table: "Policemen",
                column: "CertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Policemen_Certificate_CertificateId",
                table: "Policemen",
                column: "CertificateId",
                principalTable: "Certificate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policemen_Certificate_CertificateId",
                table: "Policemen");

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropIndex(
                name: "IX_Policemen_CertificateId",
                table: "Policemen");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "Policemen");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Policemen");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Policemen",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
