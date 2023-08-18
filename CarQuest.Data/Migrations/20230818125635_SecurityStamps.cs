using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarQuest.Data.Migrations
{
    public partial class SecurityStamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19b96a81-b85c-447d-8a5b-f156453c3a4f"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "05885ac1-cb58-4150-8ed1-384d2baec8bc", "8c7eafcf-f1c2-4fd4-8e66-2d71ccd49cb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0b3f5f-5558-43e9-b1b9-07b8f4451df2"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6a40f57d-1b9c-45da-a537-1e311df2f91e", "d0afe58f-353f-4af8-a83a-e27bc95c6ffc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19b96a81-b85c-447d-8a5b-f156453c3a4f"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8da29d1e-7ddf-4582-8f41-d4bc0e801ace", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0b3f5f-5558-43e9-b1b9-07b8f4451df2"),
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f21d8cb9-765c-469d-b88c-a8d1ea44e4bd", null });
        }
    }
}
