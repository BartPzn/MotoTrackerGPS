using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoTrackerGps.Migrations
{
    public partial class Init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imei",
                table: "TrackerGPS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imei",
                table: "TrackerGPS");
        }
    }
}
