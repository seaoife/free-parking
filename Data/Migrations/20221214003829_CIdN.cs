using Microsoft.EntityFrameworkCore.Migrations;

namespace FreePark.Data.Migrations
{
    public partial class CIdN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingMeter",
                table: "ParkingMeter");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ParkingMeter");

            migrationBuilder.AddColumn<int>(
                name: "parkingMeterId",
                table: "ParkingMeter",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingMeter",
                table: "ParkingMeter",
                column: "parkingMeterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ParkingMeter",
                table: "ParkingMeter");

            migrationBuilder.DropColumn(
                name: "parkingMeterId",
                table: "ParkingMeter");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ParkingMeter",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParkingMeter",
                table: "ParkingMeter",
                column: "Id");
        }
    }
}
