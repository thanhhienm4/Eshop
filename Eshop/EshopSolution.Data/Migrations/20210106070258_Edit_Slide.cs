using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EshopSolution.Data.Migrations
{
    public partial class Edit_Slide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SortOther",
                table: "Slides",
                newName: "SortOrder");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "bd13f2c4-49be-4d1e-b03a-cdb32f86b03a");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFelaKO53Lgn/fKk6Tejc4Kvmjlhu6zxVrLScidI0S+jVPO7YpjPmYtw5oSzfad0yA==");

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
                value: new DateTime(2021, 1, 6, 14, 2, 56, 5, DateTimeKind.Local).AddTicks(4196));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SortOrder",
                table: "Slides",
                newName: "SortOther");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c68ab340-8a90-49e3-9a2e-acb2f247555a");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFrSiedZPNij+bp7l6VXlFQVZKqpCxg7+2TLUyBlEG5H4jHG7YKnOrMeyG8PhRdnRg==");

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
                value: new DateTime(2021, 1, 5, 23, 14, 59, 221, DateTimeKind.Local).AddTicks(682));
        }
    }
}
