using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class CreateReceptionOfPatientsAndLinkWithHealthDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "HealthDepartment");

            migrationBuilder.CreateTable(
                name: "ReceptionOfPatients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrimarySymptoms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicineDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthDepartmentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptionOfPatients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceptionOfPatients_HealthDepartment_HealthDepartmentId",
                        column: x => x.HealthDepartmentId,
                        principalTable: "HealthDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceptionOfPatients_HealthDepartmentId",
                table: "ReceptionOfPatients",
                column: "HealthDepartmentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceptionOfPatients");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "HealthDepartment",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
