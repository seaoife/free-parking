using Microsoft.EntityFrameworkCore.Migrations;

namespace FreePark.Data.Migrations
{
    public partial class AddParkInputTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkInputPage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    LocationSelect = table.Column<string>(nullable: true),
                    ParkNearVenueSelect = table.Column<string>(nullable: true),
                    FreeParkingCheckBox = table.Column<bool>(nullable: false),
                    GarageParkingCheckbox = table.Column<bool>(nullable: false),
                    ParkingMeterLocations = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkInputPage", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkInputPage");
        }
    }
}
