using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class EditCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policemen_Certificate_CertificateId",
                table: "Policemen");

            migrationBuilder.DropIndex(
                name: "IX_Policemen_CertificateId",
                table: "Policemen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificate",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "Policemen");

            migrationBuilder.RenameTable(
                name: "Certificate",
                newName: "Certificates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Validity",
                table: "Certificates",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificateCitizenUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates");

            migrationBuilder.RenameTable(
                name: "Certificates",
                newName: "Certificate");

            migrationBuilder.AddColumn<long>(
                name: "CertificateId",
                table: "Policemen",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Validity",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificate",
                table: "Certificate",
                column: "Id");

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
    }
}
