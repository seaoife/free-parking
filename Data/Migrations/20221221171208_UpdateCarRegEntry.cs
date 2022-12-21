using Microsoft.EntityFrameworkCore.Migrations;

namespace FreePark.Data.Migrations
{
    public partial class UpdateCarRegEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CarRegEntry",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CarRegEntry_UserId",
                table: "CarRegEntry",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRegEntry_AspNetUsers_UserId",
                table: "CarRegEntry",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRegEntry_AspNetUsers_UserId",
                table: "CarRegEntry");

            migrationBuilder.DropIndex(
                name: "IX_CarRegEntry_UserId",
                table: "CarRegEntry");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CarRegEntry",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
