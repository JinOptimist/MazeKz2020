using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class DropLinkWithHealthDepartmentAndReceptionPatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceptionOfPatients_HealthDepartment_HealthDepartmentId",
                table: "ReceptionOfPatients");

            migrationBuilder.DropIndex(
                name: "IX_ReceptionOfPatients_HealthDepartmentId",
                table: "ReceptionOfPatients");

            migrationBuilder.DropColumn(
                name: "HealthDepartmentId",
                table: "ReceptionOfPatients");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "HealthDepartment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "HealthDepartmentId",
                table: "ReceptionOfPatients",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "HealthDepartment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceptionOfPatients_HealthDepartmentId",
                table: "ReceptionOfPatients",
                column: "HealthDepartmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceptionOfPatients_HealthDepartment_HealthDepartmentId",
                table: "ReceptionOfPatients",
                column: "HealthDepartmentId",
                principalTable: "HealthDepartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
