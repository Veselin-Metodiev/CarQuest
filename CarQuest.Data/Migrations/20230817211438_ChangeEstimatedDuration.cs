using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarQuest.Data.Migrations
{
    public partial class ChangeEstimatedDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedDuration",
                table: "Offers");

            migrationBuilder.AddColumn<int>(
                name: "EstimatedDurationDays",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstimatedDurationHours",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedDurationDays",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "EstimatedDurationHours",
                table: "Offers");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EstimatedDuration",
                table: "Offers",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
