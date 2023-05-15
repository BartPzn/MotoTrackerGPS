using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoTrackerGps.Migrations
{
    public partial class Init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Altitude",
                table: "TrackerGPS",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "TrackerGPS",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "TrackerGPS",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Speed",
                table: "TrackerGPS",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "TrackerGPS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TrackerGPSID",
                table: "TrackerGPS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altitude",
                table: "TrackerGPS");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "TrackerGPS");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "TrackerGPS");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "TrackerGPS");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "TrackerGPS");

            migrationBuilder.DropColumn(
                name: "TrackerGPSID",
                table: "TrackerGPS");
        }
    }
}
