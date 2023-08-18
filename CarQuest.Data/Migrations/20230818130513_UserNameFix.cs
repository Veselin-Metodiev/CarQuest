using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarQuest.Data.Migrations
{
    public partial class UserNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19b96a81-b85c-447d-8a5b-f156453c3a4f"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "2e317746-202c-4963-8f81-5145fcc5d750", "ADMIN@CARQUEST.COM", "4be442a8-0042-40e2-8613-e47925ef3142", "admin@carquest.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0b3f5f-5558-43e9-b1b9-07b8f4451df2"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "2c4620f9-4834-4394-8020-7c9e79fd0527", "TESTUSER@CARQUEST.COM", "e95e17a8-2775-4098-81bd-0b1730c37ca2", "testuser@carquest.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("347325e5-c944-4229-b29f-9c7d94d81cbd"), 0, "194bfff4-5510-43ca-a634-4509069c8c03", "testmechanicuser@carquest.com", true, "Mechanic", "Test", false, null, "TESTMECHANICUSER@CARQUEST.COM", "TESTMECHANICUSER@CARQUEST.COM", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, false, "826a034e-04a0-4f92-953e-874c66e6b705", false, "testmechanicuser@carquest.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("347325e5-c944-4229-b29f-9c7d94d81cbd"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19b96a81-b85c-447d-8a5b-f156453c3a4f"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "05885ac1-cb58-4150-8ed1-384d2baec8bc", "ADMIN", "8c7eafcf-f1c2-4fd4-8e66-2d71ccd49cb0", "Admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0b3f5f-5558-43e9-b1b9-07b8f4451df2"),
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "6a40f57d-1b9c-45da-a537-1e311df2f91e", "TESTUSER", "d0afe58f-353f-4af8-a83a-e27bc95c6ffc", "TestUser" });
        }
    }
}
