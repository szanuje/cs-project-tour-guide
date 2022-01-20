using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourGuide.Migrations
{
    public partial class RemoveName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
