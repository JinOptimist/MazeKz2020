using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class AddedViolationDeclaration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ViolationDeclarations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BlamedUserId = table.Column<long>(type: "bigint", nullable: false),
                    ViewedPolicemanId = table.Column<long>(type: "bigint", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffenseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViolationDeclarations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViolationDeclarations_CitizenUser_BlamedUserId",
                        column: x => x.BlamedUserId,
                        principalTable: "CitizenUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViolationDeclarations_CitizenUser_UserId",
                        column: x => x.UserId,
                        principalTable: "CitizenUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViolationDeclarations_Policemen_ViewedPolicemanId",
                        column: x => x.ViewedPolicemanId,
                        principalTable: "Policemen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ViolationDeclarations_BlamedUserId",
                table: "ViolationDeclarations",
                column: "BlamedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ViolationDeclarations_UserId",
                table: "ViolationDeclarations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ViolationDeclarations_ViewedPolicemanId",
                table: "ViolationDeclarations",
                column: "ViewedPolicemanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ViolationDeclarations");
        }
    }
}
