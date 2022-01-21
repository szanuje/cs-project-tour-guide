﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourGuide.Domain.Migrations
{
    public partial class AddDestinationsPlaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DestinationFK = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_places_destinations_DestinationFK",
                        column: x => x.DestinationFK,
                        principalTable: "destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_places_DestinationFK",
                table: "places",
                column: "DestinationFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "places");

            migrationBuilder.DropTable(
                name: "destinations");
        }
    }
}
