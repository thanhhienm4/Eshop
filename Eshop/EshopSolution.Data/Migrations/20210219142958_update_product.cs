using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EshopSolution.Data.Migrations
{
    public partial class update_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "6a28e009-dcad-4720-84f0-6ff57a207092");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEL91hYOooqt24u4Z5Bc2cHTfFMFnjF1jQhADYc763TEAv+plOQrmHKEk1+oB1EAdfg==");

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
                value: new DateTime(2021, 2, 19, 21, 29, 54, 238, DateTimeKind.Local).AddTicks(9484));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "7e2b12ae-89cf-4e99-abb3-ce9afd3cfa9e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEDG25sst2upHd9mcW4JjwnDgxIXtpzh4e5phtF6+2Ot4G1EHgwmQUFR75JlLj0OfXQ==");

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
                value: new DateTime(2021, 2, 5, 22, 37, 36, 747, DateTimeKind.Local).AddTicks(3184));

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
    }
}
