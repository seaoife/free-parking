using Microsoft.EntityFrameworkCore.Migrations;

namespace FreePark.Data.Migrations
{
    public partial class _2ndStreetLatLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "StreetEndlat",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "StreetStartlong",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetEndlat",
                table: "ParkingSpaces");

            migrationBuilder.DropColumn(
                name: "StreetStartlong",
                table: "ParkingSpaces");
        }
    }
}
