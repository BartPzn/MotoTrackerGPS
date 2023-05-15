﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoTrackerGps.Migrations
{
    public partial class Ini11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "TrackerGPS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "TrackerGPS");
        }
    }
}
