using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Server.Migrations
{
    public partial class newDbContextUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9512433-613d-46a3-b273-98ea7a33c7e9");

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("3c7631e3-dc7e-472e-9a14-7a7a24b9b40c"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                column: "ConcurrencyStamp",
                value: "40ba9434-3121-4465-8ca6-5bb7450a3351");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b61805b4-1114-4710-b46f-a9048aa547cf", "3d1d6c19-896f-4538-a9e3-eb2a0e2cd249", "Guest", "GUEST" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c154b6bc-5c5c-4b91-9815-e8f3fbef8625", "AQAAAAEAACcQAAAAEO7Aqu+EVWEpL5gSA5g6U8UEQPD0GxquqfjG6RlQLMQxY/OjJ9+HiQUIgUX6vO3Rlg==", "32a6b82b-eb86-4e98-a1f3-1348a52b3438" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "ApplicationUserId", "ArrivalDate", "DepartureDate", "RoomId", "RoomPrice", "TotalSum", "TransactionDateTime" },
                values: new object[] { new Guid("e4fabb77-f241-4fbc-9bef-b301a515c22c"), "2d5168cc-2092-4eaa-b62a-95ee7d587951", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11223344-5566-7788-99aa-bbccddeeff00"), 1230.0, 23456.0, new DateTimeOffset(new DateTime(2023, 3, 29, 11, 20, 17, 374, DateTimeKind.Unspecified).AddTicks(4914), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b61805b4-1114-4710-b46f-a9048aa547cf");

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: new Guid("e4fabb77-f241-4fbc-9bef-b301a515c22c"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                column: "ConcurrencyStamp",
                value: "f3d5fa14-cc42-4a48-be9d-c5825b047064");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a9512433-613d-46a3-b273-98ea7a33c7e9", "ff5062ea-5857-453c-a5a9-197aa939662a", "Guest", "GUEST" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d5168cc-2092-4eaa-b62a-95ee7d587951",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87501fcc-e4e8-4ff2-abc0-c0fa39e9d520", "AQAAAAEAACcQAAAAECPNfnMpXWkwrffaXm6jSQIGDoQl1IhZQwNQoKQpBxrlzwmt5mZVDrQQ5VCmmATV0w==", "2799986e-0b73-4029-9e95-ee035dc51bfe" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "ApplicationUserId", "ArrivalDate", "DepartureDate", "RoomId", "RoomPrice", "TotalSum", "TransactionDateTime" },
                values: new object[] { new Guid("3c7631e3-dc7e-472e-9a14-7a7a24b9b40c"), "2d5168cc-2092-4eaa-b62a-95ee7d587951", new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("11223344-5566-7788-99aa-bbccddeeff00"), 0.0, 23456.0, new DateTimeOffset(new DateTime(2023, 3, 28, 22, 28, 48, 968, DateTimeKind.Unspecified).AddTicks(7723), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
