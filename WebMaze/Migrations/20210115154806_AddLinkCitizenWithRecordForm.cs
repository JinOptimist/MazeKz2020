using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class AddLinkCitizenWithRecordForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CitizenIdId",
                table: "RecordForms",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecordForms_CitizenIdId",
                table: "RecordForms",
                column: "CitizenIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecordForms_CitizenUser_CitizenIdId",
                table: "RecordForms",
                column: "CitizenIdId",
                principalTable: "CitizenUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecordForms_CitizenUser_CitizenIdId",
                table: "RecordForms");

            migrationBuilder.DropIndex(
                name: "IX_RecordForms_CitizenIdId",
                table: "RecordForms");

            migrationBuilder.DropColumn(
                name: "CitizenIdId",
                table: "RecordForms");
        }
    }
}
