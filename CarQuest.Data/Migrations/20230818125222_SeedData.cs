using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarQuest.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("19b96a81-b85c-447d-8a5b-f156453c3a4f"), 0, "8da29d1e-7ddf-4582-8f41-d4bc0e801ace", "admin@carquest.com", true, "Admin", "Admin", false, null, "ADMIN@CARQUEST.COM", "ADMIN", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, false, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ce0b3f5f-5558-43e9-b1b9-07b8f4451df2"), 0, "f21d8cb9-765c-469d-b88c-a8d1ea44e4bd", "testuser@carquest.com", true, "Test", "User", false, null, "TESTUSER@CARQUEST.COM", "TESTUSER", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", null, false, null, false, "TestUser" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "ImageUrl", "Mileage", "Model", "OwnerId", "Year" },
                values: new object[] { new Guid("78acc508-53b5-4976-a07a-c0a8ba9ea0c8"), "Ford", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fgreenrentacar.bg%2Fen%2Feconomy%2F63-yaris-cross-at&psig=AOvVaw2smYuUgRrL1SgtVHRz5OcN&ust=1691856354351000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCMi8ipv-1IADFQAAAAAdAAAAABAE", "100000", "Focus", new Guid("ce0b3f5f-5558-43e9-b1b9-07b8f4451df2"), "2012" });

            migrationBuilder.InsertData(
                table: "Mechanics",
                columns: new[] { "Id", "PhoneNumber", "ShopAddress", "UserId" },
                values: new object[] { new Guid("56942f96-8e95-472e-a5cd-471146bbbb75"), "+359888888888", "Test Address", new Guid("ce0b3f5f-5558-43e9-b1b9-07b8f4451df2") });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AssignedMechanicId", "CarId", "Description", "OfferId", "OwnerId", "Status", "Title" },
                values: new object[] { new Guid("3e01b97f-98e4-421f-8552-2159301e1d15"), new Guid("56942f96-8e95-472e-a5cd-471146bbbb75"), new Guid("78acc508-53b5-4976-a07a-c0a8ba9ea0c8"), "Test Description", null, new Guid("ce0b3f5f-5558-43e9-b1b9-07b8f4451df2"), 1, "Test Title" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19b96a81-b85c-447d-8a5b-f156453c3a4f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("3e01b97f-98e4-421f-8552-2159301e1d15"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("78acc508-53b5-4976-a07a-c0a8ba9ea0c8"));

            migrationBuilder.DeleteData(
                table: "Mechanics",
                keyColumn: "Id",
                keyValue: new Guid("56942f96-8e95-472e-a5cd-471146bbbb75"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0b3f5f-5558-43e9-b1b9-07b8f4451df2"));
        }
    }
}
