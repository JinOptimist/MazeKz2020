using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class UpdateBus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bus_BusRoute_BusRouteId",
                table: "Bus");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Bus");

            migrationBuilder.AlterColumn<long>(
                name: "BusRouteId",
                table: "Bus",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "BusModel",
                table: "Bus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BusOrder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TargetedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusWorker",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    License = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusWorker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusWorker_Bus_BusId",
                        column: x => x.BusId,
                        principalTable: "Bus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusWorker_BusId",
                table: "BusWorker",
                column: "BusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bus_BusRoute_BusRouteId",
                table: "Bus",
                column: "BusRouteId",
                principalTable: "BusRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bus_BusRoute_BusRouteId",
                table: "Bus");

            migrationBuilder.DropTable(
                name: "BusOrder");

            migrationBuilder.DropTable(
                name: "BusWorker");

            migrationBuilder.DropColumn(
                name: "BusModel",
                table: "Bus");

            migrationBuilder.AlterColumn<long>(
                name: "BusRouteId",
                table: "Bus",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "WorkerId",
                table: "Bus",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Bus_BusRoute_BusRouteId",
                table: "Bus",
                column: "BusRouteId",
                principalTable: "BusRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
