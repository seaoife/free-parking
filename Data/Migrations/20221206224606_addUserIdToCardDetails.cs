using Microsoft.EntityFrameworkCore.Migrations;

namespace FreePark.Data.Migrations
{
    public partial class addUserIdToCardDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CarDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CarDetails");
        }
    }
}
