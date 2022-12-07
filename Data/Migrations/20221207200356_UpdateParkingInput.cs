using Microsoft.EntityFrameworkCore.Migrations;

namespace FreePark.Data.Migrations
{
    public partial class UpdateParkingInput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "ParkInputPage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "ParkInputPage");
        }
    }
}
