using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoTrackerGps.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrackerGPS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackerIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackerPort = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackerGPS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TrackingData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackerGPSID = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Speed = table.Column<double>(type: "float", nullable: false),
                    Altitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrackingData_TrackerGPS_TrackerGPSID",
                        column: x => x.TrackerGPSID,
                        principalTable: "TrackerGPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackingData_TrackerGPSID",
                table: "TrackingData",
                column: "TrackerGPSID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackingData");

            migrationBuilder.DropTable(
                name: "TrackerGPS");
        }
    }
}
