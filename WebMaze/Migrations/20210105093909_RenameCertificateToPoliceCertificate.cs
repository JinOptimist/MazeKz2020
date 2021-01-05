using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class RenameCertificateToPoliceCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificateCitizenUser");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.CreateTable(
                name: "PoliceCertificates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Validity = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceCertificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CitizenUserPoliceCertificate",
                columns: table => new
                {
                    PoliceCertificatesId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenUserPoliceCertificate", x => new { x.PoliceCertificatesId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CitizenUserPoliceCertificate_CitizenUser_UserId",
                        column: x => x.UserId,
                        principalTable: "CitizenUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitizenUserPoliceCertificate_PoliceCertificates_PoliceCertificatesId",
                        column: x => x.PoliceCertificatesId,
                        principalTable: "PoliceCertificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitizenUserPoliceCertificate_UserId",
                table: "CitizenUserPoliceCertificate",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitizenUserPoliceCertificate");

            migrationBuilder.DropTable(
                name: "PoliceCertificates");

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Validity = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificateCitizenUser",
                columns: table => new
                {
                    CertificatesId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateCitizenUser", x => new { x.CertificatesId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CertificateCitizenUser_Certificates_CertificatesId",
                        column: x => x.CertificatesId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificateCitizenUser_CitizenUser_UserId",
                        column: x => x.UserId,
                        principalTable: "CitizenUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CertificateCitizenUser_UserId",
                table: "CertificateCitizenUser",
                column: "UserId");
        }
    }
}
