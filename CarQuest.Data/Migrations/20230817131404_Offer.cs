using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarQuest.Data.Migrations
{
    public partial class Offer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OfferId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EstimatedDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OfferId",
                table: "Tickets",
                column: "OfferId",
                unique: true,
                filter: "[OfferId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Offers_OfferId",
                table: "Tickets",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Offers_OfferId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_OfferId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Tickets");
        }
    }
}
