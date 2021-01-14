using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMaze.Migrations
{
    public partial class AddPropertiesToCitizenUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "CitizenUser",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "CitizenUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CitizenUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "CitizenUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "CitizenUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "CitizenUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDead",
                table: "CitizenUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                table: "CitizenUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "CitizenUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "CitizenUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "CitizenUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "CitizenUser");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "CitizenUser");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CitizenUser");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "CitizenUser");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "CitizenUser");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "CitizenUser");

            migrationBuilder.DropColumn(
                name: "IsDead",
                table: "CitizenUser");

            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                table: "CitizenUser");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "CitizenUser");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "CitizenUser");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "CitizenUser");
        }
    }
}
