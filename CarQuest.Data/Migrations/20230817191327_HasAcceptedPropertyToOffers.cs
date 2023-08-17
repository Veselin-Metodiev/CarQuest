using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarQuest.Data.Migrations
{
    public partial class HasAcceptedPropertyToOffers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasUserAccepted",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasUserAccepted",
                table: "Offers");
        }
    }
}
