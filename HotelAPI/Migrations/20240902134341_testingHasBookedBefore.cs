using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAPI.Migrations
{
    public partial class testingHasBookedBefore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsBookedBefore",
                table: "Customers",
                newName: "HasBookedBefore");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HasBookedBefore",
                table: "Customers",
                newName: "IsBookedBefore");
        }
    }
}
