using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EshopSolution.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9257fb08-0679-41eb-a0b4-926a5a10697b"),
                column: "ConcurrencyStamp",
                value: "0094d104-c805-4e07-83aa-99d35fb0de2f");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("c85f7c8e-462a-42d0-9d04-fa520f9c82d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f02f813c-8bb0-4850-bfea-355c51b54fb4", "AQAAAAEAACcQAAAAEE8JS7afaP9tA72c35oXnQN8ThtIHQR22KK9LCGmbPZbg5ty58CXs3smipK47Ihhtg==", "" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 8, 18, 17, 56, 55, 543, DateTimeKind.Local).AddTicks(3549));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9257fb08-0679-41eb-a0b4-926a5a10697b"),
                column: "ConcurrencyStamp",
                value: "4ab8eaae-ff33-4101-a696-56e21db5f5d8");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("c85f7c8e-462a-42d0-9d04-fa520f9c82d9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67f9b753-51d3-49f1-b115-3eb5dc0c8cb4", "AQAAAAEAACcQAAAAEEqRbGBuqCBdbTqFc423Fqys8O04CkzaVfqhRhFmJqvzSzfZcydpWyHzTCeUsFcyUQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 8, 18, 17, 46, 7, 439, DateTimeKind.Local).AddTicks(5695));
        }
    }
}
