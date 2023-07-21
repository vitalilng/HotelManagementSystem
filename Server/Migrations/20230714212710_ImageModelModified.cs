using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Server.Migrations
{
    public partial class ImageModelModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed230c85-26c2-41da-b251-d2d853de3b9b");

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("ec807f42-5713-45c6-9aa7-920b736d3112"));

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Image",
                newName: "FileName");

            migrationBuilder.AddColumn<string>(
                name: "Base64Data",
                table: "Image",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Image",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                column: "ConcurrencyStamp",
                value: "fee208f5-0cbc-42d2-b2d4-4bdb4d3ba16a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "833368a9-0910-4e9c-97e7-dc4836ea92d1", "79a95988-b751-4ac4-a557-3f50e815cbd5", "Guest", "GUEST" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c797a1af-eb30-4c2d-aada-c449dd16778f", "AQAAAAEAACcQAAAAELOQ+zNjmdT0f8C5wb9c7sc+MDnO1aCHZa5maYg1iWt1lNTQuTCtxO9PB2QPNVrs9w==", "e6f3a383-2a37-474c-8291-3050f3c1d0e3" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "ApplicationUserId", "ArrivalDate", "DepartureDate", "RoomId", "RoomPrice", "TotalSum", "TransactionDateTime" },
                values: new object[] { new Guid("b366e970-394e-48f0-87d7-0c0784bf7d99"), "2d5168cc-2092-4eaa-b62a-95ee7d587951", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11223344-5566-7788-99aa-bbccddeeff00"), 1230.0, 23456.0, new DateTimeOffset(new DateTime(2023, 7, 15, 0, 27, 9, 828, DateTimeKind.Unspecified).AddTicks(4781), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833368a9-0910-4e9c-97e7-dc4836ea92d1");

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("b366e970-394e-48f0-87d7-0c0784bf7d99"));

            migrationBuilder.DropColumn(
                name: "Base64Data",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Image",
                newName: "Data");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                column: "ConcurrencyStamp",
                value: "353d4dde-acc8-4d9a-b43e-d36fb04e8dbc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed230c85-26c2-41da-b251-d2d853de3b9b", "e5cab9e2-2871-4bca-845f-7ec49594933a", "Guest", "GUEST" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfc5d3ab-8bcf-4e34-9842-0f158cb226c5", "AQAAAAEAACcQAAAAEF9BB4DEpG0Cq7MQe1by+x/37d11KHq7EU4WzSQaR2LdpWw307bKoVmEWE/NAxaOGA==", "08fa8ff2-70a2-4bb5-aaee-f76636de9ad4" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "ApplicationUserId", "ArrivalDate", "DepartureDate", "RoomId", "RoomPrice", "TotalSum", "TransactionDateTime" },
                values: new object[] { new Guid("ec807f42-5713-45c6-9aa7-920b736d3112"), "2d5168cc-2092-4eaa-b62a-95ee7d587951", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11223344-5566-7788-99aa-bbccddeeff00"), 1230.0, 23456.0, new DateTimeOffset(new DateTime(2023, 7, 14, 13, 53, 3, 635, DateTimeKind.Unspecified).AddTicks(2812), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
