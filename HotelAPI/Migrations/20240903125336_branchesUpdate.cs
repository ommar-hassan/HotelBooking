using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAPI.Migrations
{
    public partial class branchesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_HotelBranch_HotelBranchId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelBranch",
                table: "HotelBranch");

            migrationBuilder.RenameTable(
                name: "HotelBranch",
                newName: "HotelBranches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelBranches",
                table: "HotelBranches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_HotelBranches_HotelBranchId",
                table: "Bookings",
                column: "HotelBranchId",
                principalTable: "HotelBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_HotelBranches_HotelBranchId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelBranches",
                table: "HotelBranches");

            migrationBuilder.RenameTable(
                name: "HotelBranches",
                newName: "HotelBranch");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelBranch",
                table: "HotelBranch",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_HotelBranch_HotelBranchId",
                table: "Bookings",
                column: "HotelBranchId",
                principalTable: "HotelBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
