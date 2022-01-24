using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourGuide.Domain.Migrations
{
    public partial class MoveLocationToAbstract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BaseLocation",
                newName: "LocationId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BaseLocation",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseLocation_DestinationFK",
                table: "BaseLocation",
                column: "DestinationFK");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseLocation_Destinations_DestinationFK",
                table: "BaseLocation",
                column: "DestinationFK",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseLocation_Destinations_DestinationFK",
                table: "BaseLocation");

            migrationBuilder.DropIndex(
                name: "IX_BaseLocation_DestinationFK",
                table: "BaseLocation");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BaseLocation");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "BaseLocation",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DestinationFK = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Places_Destinations_DestinationFK",
                        column: x => x.DestinationFK,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_DestinationFK",
                table: "Places",
                column: "DestinationFK");
        }
    }
}
