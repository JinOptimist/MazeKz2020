using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class AddLinkAdressUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OwnerId",
                table: "Adress",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adress_OwnerId",
                table: "Adress",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adress_CitizenUser_OwnerId",
                table: "Adress",
                column: "OwnerId",
                principalTable: "CitizenUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adress_CitizenUser_OwnerId",
                table: "Adress");

            migrationBuilder.DropIndex(
                name: "IX_Adress_OwnerId",
                table: "Adress");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Adress");
        }
    }
}
