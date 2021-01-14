using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class UpdateBusForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusWorker_Bus_BusId",
                table: "BusWorker");

            migrationBuilder.DropIndex(
                name: "IX_BusWorker_BusId",
                table: "BusWorker");

            migrationBuilder.DropColumn(
                name: "BusId",
                table: "BusWorker");

            migrationBuilder.AddColumn<long>(
                name: "WorkerId",
                table: "Bus",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bus_WorkerId",
                table: "Bus",
                column: "WorkerId",
                unique: true,
                filter: "[WorkerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Bus_BusWorker_WorkerId",
                table: "Bus",
                column: "WorkerId",
                principalTable: "BusWorker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bus_BusWorker_WorkerId",
                table: "Bus");

            migrationBuilder.DropIndex(
                name: "IX_Bus_WorkerId",
                table: "Bus");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Bus");

            migrationBuilder.AddColumn<long>(
                name: "BusId",
                table: "BusWorker",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_BusWorker_BusId",
                table: "BusWorker",
                column: "BusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BusWorker_Bus_BusId",
                table: "BusWorker",
                column: "BusId",
                principalTable: "Bus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
