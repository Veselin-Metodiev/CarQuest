using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarQuest.Data.Migrations
{
    public partial class Tickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedMechanicId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Mechanics_AssignedMechanicId",
                        column: x => x.AssignedMechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AssignedMechanicId",
                table: "Ticket",
                column: "AssignedMechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CarId",
                table: "Ticket",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OwnerId",
                table: "Ticket",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");
        }
    }
}
