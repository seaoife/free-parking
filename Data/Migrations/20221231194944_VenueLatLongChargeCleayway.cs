using Microsoft.EntityFrameworkCore.Migrations;

namespace FreePark.Data.Migrations
{
    public partial class VenueLatLongChargeCleayway : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Venlat",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Venlng",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "clearWayTime",
                table: "ParkingSpaces",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "zoneTarrif",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Venlat",
                table: "ParkingSpaces");

            migrationBuilder.DropColumn(
                name: "Venlng",
                table: "ParkingSpaces");

            migrationBuilder.DropColumn(
                name: "clearWayTime",
                table: "ParkingSpaces");

            migrationBuilder.DropColumn(
                name: "zoneTarrif",
                table: "ParkingSpaces");
        }
    }
}
