using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreePark.Data.Migrations
{
    public partial class TwoFieldsAddedToParkInputPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CarDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "ParkInputPage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "ParkInputPage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "ParkInputPage");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "ParkInputPage");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CarDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
