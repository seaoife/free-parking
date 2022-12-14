using Microsoft.EntityFrameworkCore.Migrations;

namespace FreePark.Data.Migrations
{
    public partial class addFieldToParkingSpaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingMeter");

            migrationBuilder.AddColumn<float>(
                name: "PMLocation1lat",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PMLocation1lng",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PMLocation1lat",
                table: "ParkingSpaces");

            migrationBuilder.DropColumn(
                name: "PMLocation1lng",
                table: "ParkingSpaces");

            migrationBuilder.CreateTable(
                name: "ParkingMeter",
                columns: table => new
                {
                    parkingMeterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PMLocation1lat = table.Column<float>(type: "real", nullable: false),
                    PMLocation1lng = table.Column<float>(type: "real", nullable: false),
                    parkingMeter = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingMeter", x => x.parkingMeterId);
                });
        }
    }
}
