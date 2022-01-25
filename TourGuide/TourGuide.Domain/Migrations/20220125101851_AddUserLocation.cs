using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourGuide.Domain.Migrations
{
    public partial class AddUserLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLocations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLocations", x => new { x.Username, x.LocationId });
                    table.ForeignKey(
                        name: "FK_UserLocations_BaseLocation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "BaseLocation",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLocations_Users_Username",
                        column: x => x.Username,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLocations_LocationId",
                table: "UserLocations",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLocations");
        }
    }
}
