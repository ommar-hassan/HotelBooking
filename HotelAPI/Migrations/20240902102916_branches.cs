using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAPI.Migrations
{
    public partial class branches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelBranchId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HotelBranch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelBranch", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HotelBranchId",
                table: "Bookings",
                column: "HotelBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_HotelBranch_HotelBranchId",
                table: "Bookings",
                column: "HotelBranchId",
                principalTable: "HotelBranch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_HotelBranch_HotelBranchId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "HotelBranch");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_HotelBranchId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "HotelBranchId",
                table: "Bookings");
        }
    }
}
