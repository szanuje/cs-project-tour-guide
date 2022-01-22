using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourGuide.Domain.Migrations
{
    public partial class AddAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressFK",
                table: "places",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressFK",
                table: "hotels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<int>(type: "INTEGER", nullable: false),
                    HouseNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_places_AddressFK",
                table: "places",
                column: "AddressFK");

            migrationBuilder.CreateIndex(
                name: "IX_hotels_AddressFK",
                table: "hotels",
                column: "AddressFK");

            migrationBuilder.AddForeignKey(
                name: "FK_hotels_addresses_AddressFK",
                table: "hotels",
                column: "AddressFK",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_places_addresses_AddressFK",
                table: "places",
                column: "AddressFK",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hotels_addresses_AddressFK",
                table: "hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_places_addresses_AddressFK",
                table: "places");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropIndex(
                name: "IX_places_AddressFK",
                table: "places");

            migrationBuilder.DropIndex(
                name: "IX_hotels_AddressFK",
                table: "hotels");

            migrationBuilder.DropColumn(
                name: "AddressFK",
                table: "places");

            migrationBuilder.DropColumn(
                name: "AddressFK",
                table: "hotels");
        }
    }
}
