using Microsoft.EntityFrameworkCore.Migrations;

namespace FreePark.Data.Migrations
{
    public partial class EndStartLatLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "StreetEndlng",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "StreetStartlat",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetEndlng",
                table: "ParkingSpaces");

            migrationBuilder.DropColumn(
                name: "StreetStartlat",
                table: "ParkingSpaces");
        }
    }
}
