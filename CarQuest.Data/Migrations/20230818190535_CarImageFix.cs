using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarQuest.Data.Migrations
{
    public partial class CarImageFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19b96a81-b85c-447d-8a5b-f156453c3a4f"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f141a96e-fae5-43a6-89a4-15e47c9eec57", "AQAAAAEAACcQAAAAELK7EaemEV1mH8XsbCpgHFtnsMJMXgpEleyHYs9hyhABJcRUv5Z2+YIl9xLA3Pg2eQ==", "8c79547b-c17b-4a5f-8f62-1923fc1e16d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("347325e5-c944-4229-b29f-9c7d94d81cbd"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da96ee0b-6ec2-401a-add0-feacbdaa120a", "AQAAAAEAACcQAAAAEHsEnLLo/xOoyXpH7N2GrLQpRVU7AOjfZZVQRA3EOx0jZdYraN59nORwSXC86yLC/Q==", "fc70ef79-4e13-49c3-8b16-19921879e33e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ce0b3f5f-5558-43e9-b1b9-07b8f4451df2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bde5027e-e56e-4864-8f6d-62d11d7b1532", "AQAAAAEAACcQAAAAEEeKC6PUkvkgbYBvHGUFN3dRMInji3Uw3Nobin3L6qyEtDKj/dIfWDLwn7CwltpKyA==", "c00b321b-8965-478c-b720-681e7522512a" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("78acc508-53b5-4976-a07a-c0a8ba9ea0c8"),
                column: "ImageUrl",
                value: "https://www.cnet.com/a/img/resize/9d18bb42850bdb40a537ff761ff96129d4aab5e1/hub/2011/04/18/35e87d3a-f0f5-11e2-8c7c-d4ae52e62bcc/34641485_OVR_1.jpg?auto=webp&width=1200");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("78acc508-53b5-4976-a07a-c0a8ba9ea0c8"),
                column: "ImageUrl",
                value: "https://www.google.com/url?sa=i&url=https%3A%2F%2Fgreenrentacar.bg%2Fen%2Feconomy%2F63-yaris-cross-at&psig=AOvVaw2smYuUgRrL1SgtVHRz5OcN&ust=1691856354351000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCMi8ipv-1IADFQAAAAAdAAAAABAE");
        }
    }
}
