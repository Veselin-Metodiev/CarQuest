using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarQuest.Data.Migrations
{
    public partial class PasswordHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19b96a81-b85c-447d-8a5b-f156453c3a4f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84fa5614-537a-46e6-90eb-c09c57705c3a", "AQAAAAEAACcQAAAAEFjUJuORyoJ5t/hh6uVQ8etULZFAxVF5MrBBAqSU4mUQOZ+2PX9GcrXtLtmEuEyzqQ==", "ada1bae8-54fd-4648-8ec3-b898a0c8eca1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("347325e5-c944-4229-b29f-9c7d94d81cbd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57a7cb0a-8646-42ce-8720-94a31a36d163", "AQAAAAEAACcQAAAAEC9P6OvHNAcu0l9MFLbp/3K1bo32DAtLSRxaG7N/1gFk+7EACx4YtqiQEvyu1YhK5A==", "1167b1ac-7945-4178-bce3-9d42be4edf36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0b3f5f-5558-43e9-b1b9-07b8f4451df2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8b65f89-cfb7-40ba-9a64-058b568ce8b8", "AQAAAAEAACcQAAAAEO1C/kJZojZAOrZcRoF85l8gzpJqgLNYnNbwYamZ5mxJq5kslib060SCaJ4eJSpGxw==", "9dc3617f-c338-4f10-a9eb-39a96d1f1968" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19b96a81-b85c-447d-8a5b-f156453c3a4f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e317746-202c-4963-8f81-5145fcc5d750", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "4be442a8-0042-40e2-8613-e47925ef3142" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("347325e5-c944-4229-b29f-9c7d94d81cbd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "194bfff4-5510-43ca-a634-4509069c8c03", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "826a034e-04a0-4f92-953e-874c66e6b705" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0b3f5f-5558-43e9-b1b9-07b8f4451df2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c4620f9-4834-4394-8020-7c9e79fd0527", "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92", "e95e17a8-2775-4098-81bd-0b1730c37ca2" });
        }
    }
}
