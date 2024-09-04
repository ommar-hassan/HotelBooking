using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAPI.Migrations
{
    public partial class nullablebookingId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Bookings_BookingId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "CheckOutDate",
                table: "Bookings",
                newName: "CheckOut");

            migrationBuilder.RenameColumn(
                name: "CheckInDate",
                table: "Bookings",
                newName: "CheckIn");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Bookings_BookingId",
                table: "Rooms",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Bookings_BookingId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "CheckOut",
                table: "Bookings",
                newName: "CheckOutDate");

            migrationBuilder.RenameColumn(
                name: "CheckIn",
                table: "Bookings",
                newName: "CheckInDate");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Bookings_BookingId",
                table: "Rooms",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
