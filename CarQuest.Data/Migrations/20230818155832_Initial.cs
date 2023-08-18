using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarQuest.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19b96a81-b85c-447d-8a5b-f156453c3a4f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a42ba46b-2bc7-4294-bfb2-56172bd8ebcf", "AQAAAAEAACcQAAAAELzj9wZY7j3a3ZRV0n+YL9si1q4xnCO9hyhegq6WuqMmrLEjNy5pGyhsTnQRe6Rd0Q==", "eab071e7-573a-48a8-8864-2d30a4d035c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("347325e5-c944-4229-b29f-9c7d94d81cbd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06510d58-8dcf-433a-a559-ce75b6945dbe", "AQAAAAEAACcQAAAAEHTpH92CVtAEfpB0xlA5VaY7zRwZXKC6XErsqq57UNpF/K8VUmf7MStVY6LEUEt9MA==", "ed4910a5-59f3-4bf8-8b73-a671d3b46b2d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0b3f5f-5558-43e9-b1b9-07b8f4451df2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c75e6376-c3b9-4be1-a55b-086749710881", "AQAAAAEAACcQAAAAEKdlIQhdqgoVme7TGegzFrPGsv5KnDctIWp2QeSbsLUwqgxXJRP8JFeq7iE6lGrb5Q==", "164c143d-cbca-4848-9273-db165420b7f1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
