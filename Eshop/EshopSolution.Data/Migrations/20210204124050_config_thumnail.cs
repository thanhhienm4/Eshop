using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EshopSolution.Data.Migrations
{
    public partial class config_thumnail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThumnailId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "2d1e27a8-490b-41ef-8011-859196d2adc6");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKfmpA83T5WIirpPLlA/FHzRFd1G1GOcScXoZzFcpL/77c9O/O1GpZqd2YxodwV2tA==");

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
                value: new DateTime(2021, 2, 4, 19, 40, 45, 487, DateTimeKind.Local).AddTicks(2616));

            migrationBuilder.CreateIndex(
                name: "IX_Products_ThumnailId",
                table: "Products",
                column: "ThumnailId",
                unique: true,
                filter: "[ThumnailId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductImages_ThumnailId",
                table: "Products",
                column: "ThumnailId",
                principalTable: "ProductImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductImages_ThumnailId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ThumnailId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ThumnailId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "6c5a407e-ddd3-4cfb-a370-6909320a7b5c");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEEJZjHofPxBQ3QASMfj/b5KZiMkNxvGLcu5s0zaWilzJxocJ7aX/e+JSTtukVbTNFA==");

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
                value: new DateTime(2021, 2, 4, 17, 26, 1, 699, DateTimeKind.Local).AddTicks(8458));
        }
    }
}
