using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class RenameColumInRecordForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecordForms_CitizenUser_CitizenIdId",
                table: "RecordForms");

            migrationBuilder.RenameColumn(
                name: "CitizenIdId",
                table: "RecordForms",
                newName: "CitizenId");

            migrationBuilder.RenameIndex(
                name: "IX_RecordForms_CitizenIdId",
                table: "RecordForms",
                newName: "IX_RecordForms_CitizenId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecordForms_CitizenUser_CitizenId",
                table: "RecordForms",
                column: "CitizenId",
                principalTable: "CitizenUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecordForms_CitizenUser_CitizenId",
                table: "RecordForms");

            migrationBuilder.RenameColumn(
                name: "CitizenId",
                table: "RecordForms",
                newName: "CitizenIdId");

            migrationBuilder.RenameIndex(
                name: "IX_RecordForms_CitizenId",
                table: "RecordForms",
                newName: "IX_RecordForms_CitizenIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecordForms_CitizenUser_CitizenIdId",
                table: "RecordForms",
                column: "CitizenIdId",
                principalTable: "CitizenUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
