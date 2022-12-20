using Microsoft.EntityFrameworkCore.Migrations;

namespace FreePark.Data.Migrations
{
    public partial class AddFieldsLocateMarkerFreePark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "StartTime",
                table: "ParkingSpaces",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "EndTime",
                table: "ParkingSpaces",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<float>(
                name: "free_paidlat",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "free_paidlng",
                table: "ParkingSpaces",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "free_paidlat",
                table: "ParkingSpaces");

            migrationBuilder.DropColumn(
                name: "free_paidlng",
                table: "ParkingSpaces");

            migrationBuilder.AlterColumn<int>(
                name: "StartTime",
                table: "ParkingSpaces",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "EndTime",
                table: "ParkingSpaces",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
