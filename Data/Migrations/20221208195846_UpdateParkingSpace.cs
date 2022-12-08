using Microsoft.EntityFrameworkCore.Migrations;

namespace FreePark.Data.Migrations
{
    public partial class UpdateParkingSpace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EndDay",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasParkingMeterLocations",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFreeParking",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StartDay",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDay",
                table: "ParkingSpaces");

            migrationBuilder.DropColumn(
                name: "HasParkingMeterLocations",
                table: "ParkingSpaces");

            migrationBuilder.DropColumn(
                name: "IsFreeParking",
                table: "ParkingSpaces");

            migrationBuilder.DropColumn(
                name: "StartDay",
                table: "ParkingSpaces");
        }
    }
}
