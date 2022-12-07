using Microsoft.EntityFrameworkCore.Migrations;

namespace FreePark.Data.Migrations
{
    public partial class UpdateParkingPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkNearVenueSelect",
                table: "ParkInputPage");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ParkInputPage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParkNearVenueSelect",
                table: "ParkInputPage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ParkInputPage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
