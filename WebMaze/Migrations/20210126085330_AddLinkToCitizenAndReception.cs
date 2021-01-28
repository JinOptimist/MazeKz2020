using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class AddLinkToCitizenAndReception : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EnrolledCitizenId",
                table: "ReceptionOfPatients",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceptionOfPatients_EnrolledCitizenId",
                table: "ReceptionOfPatients",
                column: "EnrolledCitizenId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceptionOfPatients_CitizenUser_EnrolledCitizenId",
                table: "ReceptionOfPatients",
                column: "EnrolledCitizenId",
                principalTable: "CitizenUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceptionOfPatients_CitizenUser_EnrolledCitizenId",
                table: "ReceptionOfPatients");

            migrationBuilder.DropIndex(
                name: "IX_ReceptionOfPatients_EnrolledCitizenId",
                table: "ReceptionOfPatients");

            migrationBuilder.DropColumn(
                name: "EnrolledCitizenId",
                table: "ReceptionOfPatients");
        }
    }
}
